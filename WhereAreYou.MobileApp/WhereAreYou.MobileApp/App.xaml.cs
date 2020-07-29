using Xamarin.Forms;
using Autofac;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.Sso.ApiClient;
using System.Net.Http;
using AutoMapper;
using WhereAreYou.MobileApp.Services;
using Plugin.Geolocator;
using System;

namespace WhereAreYou.MobileApp
{
    public partial class App : Application
    {
        public static IContainer Container { get; private set; } //No DI (service locator for now).

        public App()
        {
            InitializeIoC();
            InitializeComponent();
            MainPage = new AppShell();
        }

        private void InitializeIoC()
        {
            if (Container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterInstance<IMeetApiClient>(new MeetApiClient("https://api.petrweb.cz/", new HttpClient())); //TODO: Move to configuration.
                builder.RegisterInstance<ISsoApiClient>(new SsoApiClient("https://sso.petrweb.cz/", new HttpClient())); 
                builder.RegisterInstance<IMapper>(AutomapperFactory.CreateMapper()).SingleInstance(); 
                builder.RegisterInstance<ITokenDatabase>(new TokenDatabase()).SingleInstance(); //TODO: Verify (lazy initializer?)
                Container = builder.Build();
            }
        }

        protected override void OnStart()
        {
            InitGeoLocation();
        }

        protected override void OnSleep()
        {
            CrossGeolocator.Current.StopListeningAsync().Wait();
        }

        protected override void OnResume()
        {
            InitGeoLocation();
        }

        private void InitGeoLocation()
        {
            if (CrossGeolocator.IsSupported && CrossGeolocator.Current.IsGeolocationEnabled)
            {
                if (!CrossGeolocator.Current.IsListening)
                {
                    CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(20), 10, true).Wait(); 
                    //TODO: Try find better solution (with async handler)
                }
            }

            else
            {
                MainPage.DisplayAlert("WAY", "Povolte prosím sdílení polohy a spusťte aplikaci znova.", "OK");
            }
        }
    }
}
