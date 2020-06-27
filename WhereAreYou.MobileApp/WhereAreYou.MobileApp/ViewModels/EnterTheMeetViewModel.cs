using System;
using System.ComponentModel;
using System.Threading.Tasks;
using WhereAreYou.Core.Requests;
using WhereAreYou.Core.Responses;
using WhereAreYou.MeetApi.ApiClient;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class EnterTheMeetViewModel : BaseViewModel
    {
        private string nickname;
        private string inviteHash;
        private string inviteUrl;
        private string meetName;

        public EnterTheMeetViewModel()
        {
            CreateNewMeetCommand = new Command(async () => await CreateNewMeet(), () => CanCreateTheMeetAllowed);
            EnterToMeetCommand = new Command(async () => await EnterToMeet(), () => CanEnterTheMeetAllowed);
            this.PropertyChanged += OnPropertyChangedUpdateValidation; //TODO: Try update or find better solution (probably bug)
        }

        public Command CreateNewMeetCommand { get; set; }
        public Command EnterToMeetCommand { get; set; }

        public string Nickname { get => nickname; set => SetProperty(ref nickname, value); }
        public string InviteHash { get => inviteHash; set => SetProperty(ref inviteHash, value); }
        public string InviteUrl { get => inviteUrl; set => SetProperty(ref inviteUrl, value); }
        public string MeetName { get => meetName; set { SetProperty(ref meetName, value); } }

        public bool CanEnterTheMeetAllowed => !string.IsNullOrEmpty(InviteUrl) && !string.IsNullOrEmpty(Nickname);
        public bool CanCreateTheMeetAllowed => !string.IsNullOrEmpty(MeetName);

        public async Task CreateNewMeet()
        {
            var result = await MeetApiClient.CreateAsync(new CreateMeet(MeetName)); //TODO: Use automapper
            MapToCreateMeet(result);  //TODO: Change focus to Nickname.
        }

        public async Task EnterToMeet()
        {
            await Task.CompletedTask; //TODO: Open meet
        }

        private void MapToCreateMeet(CreatedMeet result)
        {
            InviteUrl = result.InviteUrl;
            InviteHash = result.InviteHash;
            MeetName = result.Name;
        }

        private void OnPropertyChangedUpdateValidation(object sender, PropertyChangedEventArgs e)
        {
            CreateNewMeetCommand.ChangeCanExecute();
            EnterToMeetCommand.ChangeCanExecute();
        }
    }
}