using Autofac;
using AutoMapper;
using System.ComponentModel;
using System.Threading.Tasks;
using WhereAreYou.MobileApp.Models;
using WhereAreYou.MobileApp.Services;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class EnterTheMeetViewModel : BaseViewModel
    {
        private readonly IMapper mapper;
        private readonly ITokenDatabase tokenDatabase;
        private EnterTheMeet enterTheMeet;

        public EnterTheMeetViewModel()
        {
            this.mapper = App.Container.Resolve<IMapper>();
            this.tokenDatabase = App.Container.Resolve<ITokenDatabase>();
            this.enterTheMeet = new EnterTheMeet();
            this.enterTheMeet.PropertyChanged += OnPropertyChangedUpdateValidation;
            this.PropertyChanged += (sender, args) =>
            {
                //TODO: Try update or find better solution (issue with Xamarin Forms Command Change Can Execute)
                this.enterTheMeet.PropertyChanged += OnPropertyChangedUpdateValidation;
            };

            CreateNewMeetCommand = new Command(async () => await CreateNewMeet(), () => CanCreateTheMeetAllowed);
            EnterToMeetCommand = new Command(async () => await EnterToMeet(), () => CanEnterTheMeetAllowed);
        }

        public Command CreateNewMeetCommand { get; set; }
        public Command EnterToMeetCommand { get; set; }

        public bool CanEnterTheMeetAllowed => !string.IsNullOrEmpty(EnterTheMeet.InviteUrl) && !string.IsNullOrEmpty(EnterTheMeet.Nickname);
        public bool CanCreateTheMeetAllowed => !string.IsNullOrEmpty(EnterTheMeet.MeetName);

        public EnterTheMeet EnterTheMeet
        {
            get
            {
                return enterTheMeet;
            }

            set
            {
                SetProperty(ref enterTheMeet, value);
            }
        }

        public async Task CreateNewMeet()
        {
            var result = await MeetApiClient.CreateAsync(mapper.Map<Core.Requests.CreateMeet>(EnterTheMeet));  //TODO: Change focus to Nickname.
            EnterTheMeet = mapper.Map<EnterTheMeet>(result);
        }

        public async Task EnterToMeet()
        {
            //TODO: Add error handling (probably global err handling)
            //TODO: Fix meet name for exists meet.
            var token = await SsoApiClient.EnterTheMeetAsync(mapper.Map<Core.Requests.EnterTheMeet>(EnterTheMeet));
            var savedToken = new SavedToken(EnterTheMeet.InviteHash, EnterTheMeet.MeetName, token.Jwt);
            await tokenDatabase.InsertOrReplaceTokenAsync(savedToken);
        }

        private void OnPropertyChangedUpdateValidation(object sender, PropertyChangedEventArgs e)
        {
            CreateNewMeetCommand.ChangeCanExecute();
            EnterToMeetCommand.ChangeCanExecute();
        }
    }
}