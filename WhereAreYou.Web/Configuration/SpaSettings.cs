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
        public string MeetApiUrl { get; set; }
        public string SsoApiUrl { get; set; }
        #endregion
    }
}
