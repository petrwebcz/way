using Xamarin.Forms;
using Autofac;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.Sso.ApiClient;
using System.Net.Http;
using AutoMapper;
using WhereAreYou.MobileApp.Services;
using Plugin.Geolocator;
using System;
using System.Threading.Tasks;

namespace WhereAreYou.MobileApp
{
    //TODO: Resolve async void problem.
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
                builder.RegisterInstance<ICacheProviderService>(new CacheProviderService()).SingleInstance();
                builder.RegisterInstance<INominatimService>(new NominatimService());
                Container = builder.Build();
            }
        }

        protected override async void OnStart()
        {
           await  InitGeoLocation();
        }

        protected override async void OnSleep()
        {
            await CrossGeolocator.Current.StopListeningAsync();
        }

        protected override async void OnResume()
        {
            await InitGeoLocation();
        }

        private async Task InitGeoLocation()
        {
            if (CrossGeolocator.IsSupported && CrossGeolocator.Current.IsGeolocationEnabled)
            {
                if (!CrossGeolocator.Current.IsListening)
                {
                    await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(20), 10, true);
                }
            }

            else
            {
               await MainPage.DisplayAlert("WAY", "Povolte prosím sdílení polohy a spusťte aplikaci znova.", "OK");
            }
        }

        private void LoadTokens()
        {

        }
    }
}
