using Autofac;
using AutoMapper;
using System.Threading.Tasks;
using System.Timers;
using WhereAreYou.Core.Responses;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.MobileApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Meet = WhereAreYou.MobileApp.Models.Meet;
using WhereAreYou.MobileApp.Services;
using WhereAreYou.MobileApp.Services.Nominatim.Model;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        private readonly IMeetApiClient meetApiClient;
        private readonly IMapper mapper;
        private readonly ICacheProviderService cacheProviderService;
        private readonly INominatimService nominatimService;

        private Token token;
        private Meet meet;
        private Timer timer;

        public PeopleViewModel()
        {
            this.meetApiClient = App.Container.Resolve<IMeetApiClient>();
            this.mapper = App.Container.Resolve<IMapper>();
            this.cacheProviderService = App.Container.Resolve<CacheProviderService>();
            this.nominatimService = App.Container.Resolve<NominatimService>();

            Meet = new Meet();
            InitTimer();
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
        public Command CopyMeetUrlToClipboardCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CopyMeetUrlToClipboardAsync();
                    await App.Current.MainPage.DisplayAlert("WAY", "Odkaz byl zkopírovat. Můžete jej poslal i přátelům bez nainstalované aplikace.", "OK");
                });
            }
        }

        private Command ReloadMeetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Device.InvokeOnMainThreadAsync(LoadMeet);
                });
            }
        }

  

        public Meet Meet
        {
            get
            {
                return meet;
            }

            set
            {
                meet = value;
            }
        }
        public Token Token
        {
            get
            {
                return token;
            }

            set
            {
                SetProperty(ref token, value);

                if (Token != null)
                {
                    ReloadMeetCommand.Execute(Token);
                }
            }
        }
        #endregion

        #region Methods
        public async Task LoadMeet()
        {
            //TODO: Try again use automapper 
            //TODO: Catch not found meet: delete meet
            //TODO: Refactor
            var result = await meetApiClient.GetAsync(Token);
            Meet.MeetUsers.Clear();
            
            foreach (var user in result.Users)
            {
                Meet.MeetUsers.Add(mapper.Map<MeetUser>(user));
            }

            Meet.MeetName = result.Meet.Name;
            Meet.MeetUrl = result.Meet.InviteUrl;
            SetProperty(ref meet, Meet);
        }

        public async Task CopyMeetUrlToClipboardAsync()
        {
            await Clipboard.SetTextAsync(Meet.MeetUrl);
        }

        public async Task<Address> GetAddressForPosition(WhereAreYou.Core.Entity.Location location)
        {
            //TODO: Cache empty result.
            var cache = cacheProviderService.Get<Address>(location.ToString());

            if(cache != null)
            {
                return cache;
            }

            var result = await nominatimService.GetAddressByGeoAsync(location);
            cacheProviderService.Set<Address>(location.ToString(), result);
            
            return result;
        }
        }
        #endregion
    }
