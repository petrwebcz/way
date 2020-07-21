using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public Token Token { get; set; } = new Token("test");
        private BaseViewModel viewModel = new BaseViewModel();

        public AppShell()
        {
            InitializeComponent();
            BindingContext = viewModel = new BaseViewModel();
            Routing.RegisterRoute("way/meet", typeof(MeetViewModel));
        }
    }
}
