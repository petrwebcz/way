using Autofac;
using AutoMapper;
using System;
using System.Threading.Tasks;
using WhereAreYou.Core.Responses;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.MobileApp.Models;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class MeetViewModel : BaseViewModel
    {
        private readonly IMeetApiClient meetApiClient;
        private readonly IMapper mapper;
        private Token token;
        private Meet meet;

        public MeetViewModel()
        {
            this.meetApiClient = App.Container.Resolve<IMeetApiClient>();
            this.mapper = App.Container.Resolve<IMapper>();
            this.Meet = new Meet();
            LoadMeetCommand = new Command(async () => await LoadMeet());
        }

        #region Properties
        public Command LoadMeetCommand { get; set; }
        public Meet Meet { get => meet; set => meet = value; }
        public Token Token
        {
            get => token;

            set
            {
                SetProperty(ref token, value);
            }
        }
        #endregion

        #region Methods
        public async Task LoadMeet()
        {
            var result = await meetApiClient.GetAsync(Token);

            foreach(var user in result.Users)
            {
                Meet.MeetUsers.Add(mapper.Map<MeetUser>(user));
            }

            SetProperty(ref meet, mapper.Map<Meet>(result));
        }
        #endregion
    }
}