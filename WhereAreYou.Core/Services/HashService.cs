using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using WhereAreYou.Core.Configuration;
using System.Web;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Services;
using Microsoft.AspNetCore.WebUtilities;

namespace WhereAreYou.Core.Utils
{
    /// <summary>
    /// Thanks to https://gist.github.com/magicsih/be06c2f60288b54d9f52856feb96ce8c
    /// </summary>
    public class AesService : IHashService
    {
        IAppSettings keysSettings;

        private static RijndaelManaged rijndael = new RijndaelManaged();
        private static System.Text.UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

        private const int CHUNK_SIZE = 128;


        private void InitializeRijndael()
        {
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;
        }

        public AesService()
        {
            InitializeRijndael();

            rijndael.KeySize = CHUNK_SIZE;
            rijndael.BlockSize = CHUNK_SIZE;

            rijndael.GenerateKey();
            rijndael.GenerateIV();
        }

        public AesService(IAppSettings settings)
        {
            this.keysSettings = settings;

            InitializeRijndael();

            rijndael.Key = Convert.FromBase64String(settings.AesRgb);
            rijndael.IV = Convert.FromBase64String(settings.AesIv);
        }

        public string Decrypt(byte[] cipher)
        {
            ICryptoTransform transform = rijndael.CreateDecryptor();
            byte[] decryptedValue = transform.TransformFinalBlock(cipher, 0, cipher.Length);
            return unicodeEncoding.GetString(decryptedValue);
        }

        public string DecryptFromBase64UrlEncoded(string base64cipher)
        {
            return Decrypt(WebEncoders.Base64UrlDecode(base64cipher));
        }

        public byte[] EncryptToByte(string plain)
        {
            ICryptoTransform encryptor = rijndael.CreateEncryptor();
            byte[] cipher = unicodeEncoding.GetBytes(plain);
            byte[] encryptedValue = encryptor.TransformFinalBlock(cipher, 0, cipher.Length);
            return encryptedValue;
        }

        public string EncryptToBase64UrlEncoded(string plain)
        {
            return WebEncoders.Base64UrlEncode(EncryptToByte(plain));
        }
    }
}
