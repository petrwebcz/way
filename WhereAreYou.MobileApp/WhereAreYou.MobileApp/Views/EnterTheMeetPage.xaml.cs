using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterTheMeetPage : ContentPage
    {
        private EnterTheMeetViewModel viewModel;

        public EnterTheMeetPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new EnterTheMeetViewModel();
        }
    }
}