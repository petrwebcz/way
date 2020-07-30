using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.Models;
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
            MessagingCenter.Subscribe<SavedToken>(this, SavedToken.TOKEN_SAVED_MESSAGE, AddMeetShellContent);
        }

        private void AddMeetShellContent(SavedToken token)
        {
            var tab = new Tab();
            tab.Route = token.MeetHash;

            tab.Items.Add(new ShellContent()
            {
                Route = "map",
                Content = new Views.MeetPage()
                {
                    Title = token.MeetName,
                    Token = new Token(token.Token) //TODO: Change token on MeetPage to string.
                },
                Title = "Mapa"
            }); ;

            tab.Items.Add(new ShellContent()
            {
                Route = "people",
                Content = new Views.People()
                {
                    Title = token.MeetName
                },
                Title = "Lidé"
            });

            tab.Title = token.MeetName;
            flyItem.Items.Add(tab); //TODO: Set active page (entered meet).
            
        }
    }
}
