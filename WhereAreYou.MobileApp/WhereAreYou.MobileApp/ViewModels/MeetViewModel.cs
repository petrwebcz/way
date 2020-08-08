using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Threading.Tasks;
using System.Timers;
using WhereAreYou.Core.Requests;
using WhereAreYou.MobileApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Meet = WhereAreYou.MobileApp.Models.Meet;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class MeetViewModel : MeetBaseViewModel
    {
        private Timer timer;

        public MeetViewModel()
        {
            Meet = new Meet();
        }

        #region Properties
        private Command InitMeetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await RunSafeAsync(AddPosition);
                    await RunSafeAsync(LoadMeet);
                });
            }
        }

        private Command ReloadMeetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await RunSafeAsync(async () => await Device.InvokeOnMainThreadAsync(LoadMeet));
                });
            }
        }

        private Command UpdatePositionCommand
        {
            get
            {
                return new Command<Plugin.Geolocator.Abstractions.Position>(async (args) =>
                {
                    await RunSafeAsync(async() => await UpdatePosition(args));
                });
            }
        }
        #endregion

        #region Methods
        public override async Task LoadMeet()
        {
            //TODO: Try again use automapper 
            var result = await meetApiClient.GetAsync(Token);
            Meet.MeetUsers.Clear();

            foreach (var user in result.Users)
            {
                Meet.MeetUsers.Add(mapper.Map<MeetUser>(user));
            }

            var position = new Xamarin.Forms.Maps.Position(result.CenterPoint.Latitude, result.CenterPoint.Longitude);

            Meet.MeetName = result.Meet.Name;
            Meet.MeetUrl = result.Meet.InviteUrl;
            Meet.MeetHash = result.Meet.InviteHash;

            Meet.CenterPoint = new Xamarin.Forms.Maps.MapSpan(position,
                                                              0.01,
                                                              0.01);

            SetProperty(ref meet, Meet);
        }

        public override void Run()
        {
            if (Token == null)
            {
                throw new ApplicationException($"{nameof(Token)} is not set.");
            }

            InitMeetCommand.Execute(Token);
            InitTimer();
            InitGeoTracking();
        }

        public async Task AddPosition()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    var addPosition = new AddOrUpdatePosition(new Core.Entity.Location(location.Latitude, location.Longitude));
                    await MeetApiClient.AddPositionAsync(addPosition, Token);
                }
            }

            catch (FeatureNotSupportedException fnsEx)
            {
                await App.Current.MainPage.DisplayAlert("WAY", "Vaše zařízení nepodporuje sdílení polohy.", "OK");
                await RemoveMeetAsync();
            }

            catch (FeatureNotEnabledException fneEx)
            {
                await App.Current.MainPage.DisplayAlert("WAY", "Povolte prosím sdílení polohy v nastavení telefonu  a oprávnění aplikace. Po opětovném spuštění aplikace můžete bez problému znovu vstoupit do setkání.", "OK");
                await RemoveMeetAsync();
            }

            catch (PermissionException pEx)
            {
                await App.Current.MainPage.DisplayAlert("WAY", "Povolte prosím sdílení polohy v nastavení telefonu  a oprávnění aplikace. Po opětovném spuštění aplikace můžete bez problému znovu vstoupit do setkání.", "OK");
                await RemoveMeetAsync();
            }
        }

        public async Task UpdatePosition(Plugin.Geolocator.Abstractions.Position position)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position), $"Update position error: {nameof(position)} is null.");
            }

            var updatePosition = new AddOrUpdatePosition(new Core.Entity.Location(position.Latitude, position.Longitude));
            await MeetApiClient.UpdatePositionAsync(updatePosition, Token);
        }

        private void InitTimer()
        {
            this.timer = new Timer(1000);
            this.timer.Elapsed += TimerElapsed;
            this.timer.Start();
        }

        private void InitGeoTracking()
        {
            if (CrossGeolocator.Current.IsListening)
            {
                CrossGeolocator.Current.PositionChanged += PositionChanging;
                CrossGeolocator.Current.PositionError += PositionError;
            }

            else
            {
                throw new Exception($"{nameof(CrossGeolocator)} is not listening.");
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            ReloadMeetCommand.Execute(e);
        }

        private void PositionError(object sender, PositionErrorEventArgs e)
        {
            //TODO: Catch position error.
        }

        private void PositionChanging(object sender, PositionEventArgs e)
        {
            UpdatePositionCommand.Execute(e.Position);
        }
        #endregion
    }
}
