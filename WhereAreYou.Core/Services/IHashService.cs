namespace WhereAreYou.Core.Services
{
    public interface IHashService
    {
        string Decrypt(byte[] cipher);
        string DecryptFromBase64UrlEncoded(string base64cipher);
        string EncryptToBase64UrlEncoded(string plain);
        byte[] EncryptToByte(string plain);
    }
}