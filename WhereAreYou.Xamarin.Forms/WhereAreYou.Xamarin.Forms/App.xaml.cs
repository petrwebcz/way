using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhereAreYou.Xamarin.Forms.Services;
using WhereAreYou.Xamarin.Forms.Views;

namespace WhereAreYou.Xamarin.Forms
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
