using Autofac;
using AutoMapper;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Threading.Tasks;
using System.Timers;
using WhereAreYou.Core.Requests;
using WhereAreYou.Core.Responses;
using WhereAreYou.MeetApi.ApiClient;
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

        private void InitTimer()
        {
            this.timer = new Timer(1000);
            this.timer.Elapsed += TimerElapsed;
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
            throw new NotImplementedException();
        }

        private void PositionChanging(object sender, PositionEventArgs e)
        {
            UpdatePositionCommand.Execute(e);
        }

        #region Properties
        private Command InitMeetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await AddPosition();
                    await LoadMeet();
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

        private Command UpdatePositionCommand
        {
            get
            {
                return new Command<Plugin.Geolocator.Abstractions.Position>(async (args) =>
                {
                    await UpdatePosition(args);
                });
            }
        }
        #endregion

        #region Methods
        public async Task LoadMeet()
        {
            //TODO: Try again use automapper 
            //TODO: Catch not found meet: delete meet
            var result = await meetApiClient.GetAsync(Token);
            Meet.MeetUsers.Clear();

            foreach (var user in result.Users)
            {
                Meet.MeetUsers.Add(mapper.Map<MeetUser>(user));
            }

            var position = new Xamarin.Forms.Maps.Position(result.CenterPoint.Latitude, result.CenterPoint.Longitude);

            Meet.MeetName = result.Meet.Name;
            Meet.MeetUrl = result.Meet.InviteUrl;
            Meet.CenterPoint = new Xamarin.Forms.Maps.MapSpan(position,
                                                              0.01,
                                                              0.01);

            SetProperty(ref meet, Meet);
        }

        public void Run()
        {
            if (Token == null)
            {
                throw new ApplicationException($"{nameof(Token)} is not set.");
            }

            ReloadMeetCommand.Execute(Token);
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
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
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
        #endregion
    }
}
