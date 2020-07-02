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
            Token = new Token(@"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoie1widXNlclwiOntcIklkXCI6XCJlYWZiNTA2YS1hNTAxLTQ2NTUtYTA4YS05MDUwYTA3M2M4MTRcIixcIk5pY2tuYW1lXCI6XCIxXCIsXCJNZWV0SW52aXRlSGFzaFwiOlwieTBmSTRyQ05WOWN4MWgxYTFDUWczVUNIWms2UkdQeVpvYmhpbEtzaDRTazVJcmRjUy1yRTdsclBSOS15cWhCTVdGT3BtNkI3ZXRQSU5VM0pKR1g0Y0hyV0U2cV9CVENNc09kZk1RQnZXWDRcIn0sXCJtZWV0SW52aXRlSGFzaFwiOlwieTBmSTRyQ05WOWN4MWgxYTFDUWczVUNIWms2UkdQeVpvYmhpbEtzaDRTazVJcmRjUy1yRTdsclBSOS15cWhCTVdGT3BtNkI3ZXRQSU5VM0pKR1g0Y0hyV0U2cV9CVENNc09kZk1RQnZXWDRcIn0iLCJuYmYiOjE1OTM3MDkwMjcsImV4cCI6MTU5Mzc5NTQyNywiaWF0IjoxNTkzNzA5MDI3fQ.c0g4MZaEVW3AJVKNfoypCXLI4OcdFJXVtGlkISa_V5U");
            LoadMeetCommand = new Command(async () => await LoadMeet());
            LoadMeetCommand.Execute(null);

            //CenterPoint = new MapSpan(new Xamarin.Forms.Maps.Position(50.19385934655583, 14.66693449958008), 0.01, 0.01);
            //MeetUsers = new ObservableCollection<MeetUser>()
            //{
            //    new MeetUser()
            //    {
            //        Nickname = "Petr",
            //        Position = new Xamarin.Forms.Maps.Position(50.19385934655583, 14.66693449958008)
            //    },
            //    new MeetUser()
            //    {
            //        Nickname = "Franta",
            //        Position = new Xamarin.Forms.Maps.Position(50.29385934675583, 14.76693499958008)
            //    }
            //};
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