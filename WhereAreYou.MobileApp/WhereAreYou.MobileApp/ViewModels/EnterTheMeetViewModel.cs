using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WhereAreYou.Core.Requests;
using WhereAreYou.MeetApi.ApiClient;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class EnterTheMeetViewModel : BaseViewModel
    {
        private EnterTheMeet enterTheMeet;

        public EnterTheMeetViewModel()
        {
            EnterTheMeet = new EnterTheMeet();
        }

        public ICommand CreateNewMeetCommand => new Command(async () => await CreateNewMeet());
        public ICommand EnterToMeetCommand => new Command(async () => await EnterToMeet());
        public EnterTheMeet EnterTheMeet { get => enterTheMeet; set => SetProperty(ref enterTheMeet, value); }

        public async Task CreateNewMeet()
        {
            var result = await MeetApiClient.CreateAsync(new MeetApi.ApiClient.CreateMeet("New meet"));
            EnterTheMeet = new EnterTheMeet(result.InviteUrl, result.InviteUrl);
        }

        public async Task EnterToMeet()
        {
            await Task.CompletedTask; //TODO: Open meet
        }
    }
}