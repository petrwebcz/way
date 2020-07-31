using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.Models;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private BaseViewModel viewModel = new BaseViewModel();

        public AppShell()
        {
            InitializeComponent();
            BindingContext = viewModel = new BaseViewModel();
            MessagingCenter.Subscribe<SavedToken>(this, SavedToken.TOKEN_SAVED_MESSAGE, AddMeetShellContent);
        }

        private void AddMeetShellContent(SavedToken savedToken)
        {
            var tab = new Tab();
            tab.Route = savedToken.MeetHash;

            tab.Items.Add(new ShellContent()
            {
                Route = "map",
                Content = new Views.MeetPage()
                {
                    Title = savedToken.MeetName,
                    Token = new Token(savedToken.Token)
                },
                Title = "Mapa"
            }); ;

            tab.Items.Add(new ShellContent()
            {
                Route = "people",
                Content = new Views.PeoplePage()
                {
                    Title = savedToken.MeetName,
                    Token = new Token(savedToken.Token)
                },
                Title = "Lidé"
            });

            tab.Title = savedToken.MeetName;
            flyItem.Items.Add(tab); //TODO: Set active page (entered meet).
            
        }
    }
}
