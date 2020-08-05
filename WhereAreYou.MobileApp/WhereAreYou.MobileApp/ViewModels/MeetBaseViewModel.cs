using Autofac;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WhereAreYou.Core.Model;
using WhereAreYou.Core.Responses;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.MobileApp.Models;
using WhereAreYou.MobileApp.Services;

namespace WhereAreYou.MobileApp.ViewModels
{
    public abstract class MeetBaseViewModel : BaseViewModel
    {
        protected readonly IMeetApiClient meetApiClient;
        protected readonly IMapper mapper;
        protected readonly ICacheProviderService cacheProviderService;
        protected readonly INominatimService nominatimService;
        protected readonly ITokenDatabase tokenDatabase;
        protected Token token;
        protected Meet meet;
        private bool isMeetUpdateFailure;
        private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public MeetBaseViewModel()
        {
            this.meetApiClient = App.Container.Resolve<IMeetApiClient>();
            this.mapper = App.Container.Resolve<IMapper>();
            this.cacheProviderService = App.Container.Resolve<ICacheProviderService>();
            this.nominatimService = App.Container.Resolve<INominatimService>();
            this.tokenDatabase = App.Container.Resolve<ITokenDatabase>();

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

        public bool IsMeetUpdateFailure
        {
            get
            {
                return isMeetUpdateFailure;
            }

            set
            {
                SetProperty(ref isMeetUpdateFailure, value);
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
        public abstract void Run();
        public abstract Task LoadMeet();

        public async Task RunSafeAsync(Func<Task> method)
        {
            try
            {
                await method();
                IsMeetUpdateFailure = false;
            }

            catch (ApiException e)
            {
                if (e.StatusCode == 404 || e.StatusCode == 401)
                {
                    await RemoveMeetAsync();
                }
                else
                {
                    IsMeetUpdateFailure = true;
                }
            }

            catch (Exception e)
            {
                IsMeetUpdateFailure = true;
            }
        }

        protected async Task RemoveMeetAsync()
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                UserData userData = Token.ToUserData();
                await tokenDatabase.RemoveTokenAsync(userData.MeetInviteHash);
            }

            finally
            {
                semaphoreSlim.Release();
            }
        }


        #endregion
    }

    public static class TokenExtensions
    {
        public static UserData ToUserData(this Token token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = (JwtSecurityToken)handler.ReadToken(token.Jwt);
            var json = jsonToken.Claims.First(claim => claim.Type == ClaimTypes.UserData).Value;

            var userData = JsonConvert.DeserializeObject<UserData>(json);
            return userData;
        }
    }
}