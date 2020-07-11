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