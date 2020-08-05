using System.Threading.Tasks;
using System.Timers;
using WhereAreYou.MobileApp.Models;
using Xamarin.Forms;
using Meet = WhereAreYou.MobileApp.Models.Meet;
using WhereAreYou.MobileApp.Services.Nominatim.Model;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class PeopleViewModel : MeetBaseViewModel
    {
        protected Timer timer;

        public PeopleViewModel() : base()
        {
        }

        private void InitTimer()
        {
            this.timer = new Timer(10000);
            this.timer.Elapsed += TimerElapsed;
            this.timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            ReloadMeetCommand.Execute(e);
        }

        #region Properties
        protected Command ReloadMeetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await RunSafeAsync(async () => await Device.InvokeOnMainThreadAsync(LoadMeet));
                });
            }
        }
        #endregion

        #region Methods
        public async Task<Address> GetAddressForPosition(WhereAreYou.Core.Entity.Location location)
        {
            //TODO: Cache empty result.
            var cache = cacheProviderService.Get<Address>(location.ToString());

            if (cache != null)
            {
                return cache;
            }

            var result = await nominatimService.GetAddressByGeoAsync(location);
            cacheProviderService.Set<Address>(location.ToString(), result);

            return result;
        }

        public override async Task LoadMeet()
        {
            //TODO: Try again use automapper 
            
            var result = await meetApiClient.GetAsync(Token);
            Meet.MeetUsers.Clear();

            foreach (var user in result.Users)
            {
                var meetUser = mapper.Map<MeetUser>(user);
                var address = await GetAddressForPosition(user.Location);
                meetUser.Address = address.ToString();

                Meet.MeetUsers.Add(meetUser);
            }

            Meet.MeetName = result.Meet.Name;
            Meet.MeetUrl = result.Meet.InviteUrl;
            Meet.MeetHash = result.Meet.InviteHash;

            SetProperty(ref meet, Meet);
        }

        public override void Run()
        {
            ReloadMeetCommand.Execute(new { /* Empty by design */ });
            InitTimer();
        }
        #endregion
    }
}
