namespace WhereAreYou.Core.Intefaces
{
    public interface IAppSettings : IUrlSettings, IDatabaseSettings, ISecretSettings
    {

    }

    public interface IDatabaseSettings
    {
        string CosmosEndpoint { get; set; }
        string EmulatorKey { get; set; }
        string DatabaseId { get; set; }
        string CollectionId { get; set; }
    }

    public interface IUrlSettings
    {
        string BaseInviteUrl { get; set; }
        string WebUrl { get; set; }
        string MeetApiUrl { get; set; }
        string SsoApiUrl { get; set; }
    }

    public interface ISecretSettings
    {
        string AesRgb { get; set; }
        string AesIv { get; set; }
        string JwtSecret { get; set; }
        byte[] JwtSecretBytes { get; }
        byte[] AesRgbBytes { get; }
        byte[] AesIvBytes { get; }
    }
}