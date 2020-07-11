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
            Token = new Token(@"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoie1widXNlclwiOntcIklkXCI6XCI3OTU2Y2I0My1hMTk3LTQ1ZjAtYjI1MS1mMmQyYjdlZWMzMjRcIixcIk5pY2tuYW1lXCI6XCIxXCIsXCJNZWV0SW52aXRlSGFzaFwiOlwiZHZpc3kzQVZpblNyY2Z3M0V4U2VBRzN4Zmo0c0lDaTZwZm9DY3RndTN0U0lWazh3dVA4S3BJQXdYZVBfVnVldzFpSzQzcHZzM2NSMHk4VmFkWmdfUzI3TnBONjM1RlZRdGZBWXJ4c3Q3YlFcIn0sXCJtZWV0SW52aXRlSGFzaFwiOlwiZHZpc3kzQVZpblNyY2Z3M0V4U2VBRzN4Zmo0c0lDaTZwZm9DY3RndTN0U0lWazh3dVA4S3BJQXdYZVBfVnVldzFpSzQzcHZzM2NSMHk4VmFkWmdfUzI3TnBONjM1RlZRdGZBWXJ4c3Q3YlFcIn0iLCJuYmYiOjE1OTQ0NzYxODYsImV4cCI6MTU5NDU2MjU4NiwiaWF0IjoxNTk0NDc2MTg2fQ.ujVllTJd_PgHhpsVBZVdKPM2BnHBz8b8wMbxnnnDAa8");
            LoadMeetCommand = new Command(async () => await LoadMeet());
            LoadMeetCommand.Execute(null);
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