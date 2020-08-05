using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Meet = WhereAreYou.MobileApp.Models.Meet;
using WhereAreYou.MobileApp.Services.Nominatim.Model;
using WhereAreYou.MobileApp.Services;
using Autofac;
using System;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class SettingsViewModel : MeetBaseViewModel
    {
        private bool isCopyEnabled;
        private bool isRemoveMeetEnabled;

        public SettingsViewModel() : base()
        {
        }

        #region Properties
        public Command CopyMeetUrlToClipboardCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CopyMeetUrlToClipboardAsync();
                    await App.Current.MainPage.DisplayAlert("WAY", "Odkaz byl zkopírovat. Můžete jej poslal i přátelům bez nainstalované aplikace.", "OK");
                });
            }
        }

        public Command RemoveMeetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await RemoveMeetAsync();
                });
            }
        }

        protected Command ReloadMeetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await RunSafeAsync(async () => await Device.InvokeOnMainThreadAsync(LoadMeet));
                });
            }
        }

        public bool IsCopyEnabled
        {
            get
            {
                return isCopyEnabled;
            }

            set
            {
                if(value)
                {
                    CopyMeetUrlToClipboardCommand.Execute(new { /* Empty by design */ });
                }

                SetProperty(ref isCopyEnabled, value);
            }
        }

        public bool IsRemoveMeetEnabled
        {
            get
            {
                return isRemoveMeetEnabled;
            }

            set
            {
                if (value)
                {
                    RemoveMeetCommand.Execute(new { /* Empty by design */ });
                }

                SetProperty(ref isRemoveMeetEnabled, value);
            }
        }

        #endregion

        #region Methods
        public async Task CopyMeetUrlToClipboardAsync()
        {
            await Clipboard.SetTextAsync(Meet.MeetUrl);
        }

        public async Task<Address> GetAddressForPosition(WhereAreYou.Core.Entity.Location location)
        {
            //TODO: Cache empty result.
            var cache = cacheProviderService.Get<Address>(location.ToString());

            if (cache != null)
            {
                return cache;
            }

            var result = await nominatimService.GetAddressByGeoAsync(location);
            cacheProviderService.Set<Address>(location.ToString(), result);

            return result;
        }

        public override async Task LoadMeet()
        {
            var result = await meetApiClient.GetAsync(Token);

            Meet.MeetName = result.Meet.Name;
            Meet.MeetUrl = result.Meet.InviteUrl;
            Meet.MeetHash = result.Meet.InviteHash;

            SetProperty(ref meet, Meet);
        }

        public override void Run()
        {
            ReloadMeetCommand.Execute(new { /* Empty by design */ });
        }
        #endregion
    }
}
