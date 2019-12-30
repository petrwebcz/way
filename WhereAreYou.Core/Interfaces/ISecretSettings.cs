namespace WhereAreYou.Core.Intefaces
{
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