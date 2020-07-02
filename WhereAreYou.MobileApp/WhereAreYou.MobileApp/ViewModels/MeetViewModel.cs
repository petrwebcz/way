using Autofac;
using AutoMapper;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WhereAreYou.Core.Responses;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.MobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class MeetViewModel : BaseViewModel
    {
        private MapSpan centerPoint;
        private string meetName;
        private Token token;
        private readonly IMeetApiClient meetApiClient;
        private readonly IMapper mapper;

        public MeetViewModel()
        {
            this.meetApiClient = App.Container.Resolve<IMeetApiClient>();
            this.mapper = App.Container.Resolve<IMapper>();
          
            Token = new Token(@"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlBldHIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoie1widXNlclwiOntcIklkXCI6XCJkYjU0Mzg2Zi1hMDVhLTQwYWYtODQ1OS1lMWM3ZTg0ZjM1ZDdcIixcIk5pY2tuYW1lXCI6XCJQZXRyXCIsXCJNZWV0SW52aXRlSGFzaFwiOlwiTVFCeXFoeXFHUzN5NnZLM3RYOW91R2xNVnVlR3JCWXc4R1YxUUdvaC05Q0dmY3lFRl9FTHh2dFJsR0RSUUROSkpsTTRVaWdqaFJqZlRSbnE2SGxsdTZpWDlnVHlwN3VXZ2lUVzY4LXBEWnNcIn0sXCJtZWV0SW52aXRlSGFzaFwiOlwiTVFCeXFoeXFHUzN5NnZLM3RYOW91R2xNVnVlR3JCWXc4R1YxUUdvaC05Q0dmY3lFRl9FTHh2dFJsR0RSUUROSkpsTTRVaWdqaFJqZlRSbnE2SGxsdTZpWDlnVHlwN3VXZ2lUVzY4LXBEWnNcIn0iLCJuYmYiOjE1OTM2OTM1MTUsImV4cCI6MTU5Mzc3OTkxNSwiaWF0IjoxNTkzNjkzNTE1fQ.g5rBGnbhptD7_Ukh8J_ZmHnt29B9H2C7Px_Lo2ILGDc");
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

        public MapSpan CenterPoint
        {
            get => centerPoint;

            set
            {
                SetProperty(ref centerPoint, value);
            }
        }

        public string MeetName
        {
            get => meetName;

            set
            {
                SetProperty(ref meetName, value);
            }
        }

        public Token Token
        {
            get => token;

            set
            {
                SetProperty(ref token, value);
            }
        }

        public ObservableCollection<MeetUser> MeetUsers { get; set; }
        #endregion

        #region Methods
        public async Task LoadMeet()
        {
            var result = await meetApiClient.GetAsync(Token);
            this.CenterPoint = mapper.Map<MapSpan>(result.CenterPoint);

            foreach (var user in result.Users)
            {
                MeetUsers.Add(mapper.Map<MeetUser>(user));
            }
        }
        #endregion
    }
}