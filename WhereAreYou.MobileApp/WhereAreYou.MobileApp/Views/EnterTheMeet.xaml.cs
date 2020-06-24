using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterTheMeet : ContentPage
    {
        private EnterTheMeetViewModel viewModel;

        public EnterTheMeet()
        {
            InitializeComponent();
            BindingContext = viewModel = new EnterTheMeetViewModel();
        }
    }
}