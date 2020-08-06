using Autofac;
using AutoMapper;
using System;
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
            try
            {
                var result = await MeetApiClient.CreateAsync(mapper.Map<Core.Requests.CreateMeet>(EnterTheMeet));  //TODO: Change focus to Nickname.
                EnterTheMeet = mapper.Map<EnterTheMeet>(result);
            }

            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("WAY", "Nepodařilo se vytvořit setkání, zkuste to prosím později.", "OK");
            }
        }

        public async Task EnterToMeet()
        {
            try
            {
                var token = await SsoApiClient.EnterTheMeetAsync(mapper.Map<Core.Requests.EnterTheMeet>(EnterTheMeet));
                await tokenDatabase.InsertOrReplaceTokenAsync(new SavedToken(EnterTheMeet.MeetName, token.Jwt));
            }

            catch (WhereAreYou.Sso.ApiClient.ApiException e)
            {
                if (e.StatusCode == 404 || e.StatusCode == 401)
                {
                    await App.Current.MainPage.DisplayAlert("WAY", "Adresa setkání neexistuje, vytvořte si prosím jiné.", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("WAY", "Nepodařilo se vstoupit do setkání, zkuste to prosím později.", "OK");
                }
            }

            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("WAY", "Nepodařilo se vstoupit do setkání, zkuste to prosím později.", "OK");
            }
        }

        private void OnPropertyChangedUpdateValidation(object sender, PropertyChangedEventArgs e)
        {
            CreateNewMeetCommand.ChangeCanExecute();
            EnterToMeetCommand.ChangeCanExecute();
        }
    }
}