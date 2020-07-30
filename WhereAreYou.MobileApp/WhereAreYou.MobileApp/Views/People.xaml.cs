using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class People : ContentPage
    {
        //TODO: Add viewmodel locator or find solution for share meet object between pages.
        public People()
        {
            InitializeComponent();
        }
    }
}