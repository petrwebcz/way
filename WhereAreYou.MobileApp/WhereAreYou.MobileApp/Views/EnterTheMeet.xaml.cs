using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterTheMeet : ContentPage
    {
        private EnterTheMeetViewModel viewModel;

        public EnterTheMeet(EnterTheMeetViewModel enterTheMeetViewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = enterTheMeetViewModel;
        }

        public EnterTheMeet()
        {
            InitializeComponent();

            viewModel = new EnterTheMeetViewModel(new Core.Requests.EnterTheMeet());

            BindingContext = viewModel;
        }
    }
}