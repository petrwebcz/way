using Autofac;
using AutoMapper;
using System.Threading.Tasks;
using WhereAreYou.Core.Responses;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.MobileApp.Models;
using WhereAreYou.MobileApp.Services;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class MeetBaseViewModel : BaseViewModel
    {
        protected readonly IMeetApiClient meetApiClient;
        protected readonly IMapper mapper;
        protected readonly ICacheProviderService cacheProviderService;
        protected readonly INominatimService nominatimService;
        protected Token token;
        protected Meet meet;

        public MeetBaseViewModel()
        {
            this.meetApiClient = App.Container.Resolve<IMeetApiClient>();
            this.mapper = App.Container.Resolve<IMapper>();
            this.cacheProviderService = App.Container.Resolve<ICacheProviderService>();
            this.nominatimService = App.Container.Resolve<INominatimService>();

            Meet = new Meet();
        }

        #region Properties
        public Meet Meet
        {
            get
            {
                return meet;
            }

            set
            {
                meet = value;
            }
        }

        public Token Token
        {
            get
            {
                return token;
            }

            set
            {
                SetProperty(ref token, value);
                             
            }
        }
        #endregion

        #region Methods
        
        #endregion
    }
}