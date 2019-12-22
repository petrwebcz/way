using System;
using System.Text;

namespace WhereAreYou.Web.Configuration
{
    public class SpaSettings : ISpaSettings
    {
        public SpaSettings()
        {

        }

        #region URL settings
        public string BaseInviteUrl { get; set; }
        public string WebUrl { get; set; }
        public string RoomApiUrl { get; set; }
        public string SsoApiUrl { get; set; }
        #endregion
    }
}
