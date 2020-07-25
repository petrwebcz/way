using Autofac;
using AutoMapper;
using System;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Responses;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.MobileApp.Models;
using Xamarin.Forms;
using Meet = WhereAreYou.MobileApp.Models.Meet;

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
            LoadMeetCommand = new Command(async () => await LoadMeet()); //TODO: Use async command
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

                if (Token != null)
                {
                    LoadMeetCommand.Execute(Token);
                }
            }
        }
        #endregion

        #region Methods
        public async Task LoadMeet()
        {
            //TODO: Try again use automapper
            var result = await meetApiClient.GetAsync(Token);

            foreach(var user in result.Users)
            {
                Meet.MeetUsers.Add(mapper.Map<MeetUser>(user));
            }

            Meet.MeetName = result.Meet.Name;
            Meet.CenterPoint = new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(result.CenterPoint.Latitude, result.CenterPoint.Longitude), 0.01, 0.01);
            SetProperty(ref meet, Meet);
        }

        public async Task UpdatePosition()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}