using System;
using System.Text;
using WhereAreYou.Core.Intefaces;

namespace WhereAreYou.Core.Configuration
{
    public class AppSettings : IAppSettings
    {
        public AppSettings()
        {

        }

        #region Encryption keys settings
        public string AesRgb { get; set; }
        public string AesIv { get; set; }
        public string JwtSecret { get; set; }
        public byte[] JwtSecretBytes => !string.IsNullOrEmpty(JwtSecret) ? ASCIIEncoding.UTF8.GetBytes(JwtSecret) : new byte[] { };
        public byte[] AesRgbBytes => !string.IsNullOrEmpty(AesRgb) ? ASCIIEncoding.UTF8.GetBytes(AesRgb) : new byte[] { };
        public byte[] AesIvBytes => !string.IsNullOrEmpty(AesIv) ? ASCIIEncoding.UTF8.GetBytes(AesIv) : new byte[] { };
        #endregion

        #region Database settings
        public string CosmosEndpoint { get; set; }
        public string EmulatorKey { get; set; }
        public string DatabaseId { get; set; }
        public string CollectionId { get; set; }
        #endregion

        #region URL settings
        public string BaseInviteUrl { get; set; }
        public string WebUrl { get; set; }
        public string MeetApiUrl { get; set; }
        public string SsoApiUrl { get; set; }
        #endregion
    }
}
