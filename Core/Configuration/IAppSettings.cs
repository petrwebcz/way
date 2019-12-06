namespace WhereAreYou.Core.Configuration
{
    public interface IAppSettings
    {
        string AesIv { get; set; }
        byte[] AesIvBytes { get; }
        string AesRgb { get; set; }
        byte[] AesRgbBytes { get; }
        string CollectionId { get; set; }
        string CosmosEndpoint { get; set; }
        string DatabaseId { get; set; }
        string EmulatorKey { get; set; }
        string JwtSecret { get; set; }
        byte[] JwtSecretBytes { get; }
    }
}