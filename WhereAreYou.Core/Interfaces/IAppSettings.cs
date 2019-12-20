namespace WhereAreYou.Core.Intefaces
{
   public interface IAppSettings
    {
        #region Encryption keys settings
        string AesRgb { get; set; }
        string AesIv { get; set; }
        string JwtSecret { get; set; }
        byte[] JwtSecretBytes { get; }
        byte[] AesRgbBytes { get; }
        byte[] AesIvBytes { get; }
        #endregion

        #region Database settings
        string CosmosEndpoint { get; set; }
        string EmulatorKey { get; set; }
        string DatabaseId { get; set; }
        string CollectionId { get; set; }
        #endregion

        #region URL settings
        string BaseInviteUrl { get; set; }
        string WebUrl { get; set; }
        string RoomApiUrl { get; set; }
        string SsoApiUrl { get; set; }
        #endregion
    }
}