using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WhereAreYou.Core.Utils;

namespace WhereAreYou.Core.UnitTests
{
    [TestClass]
    public class HashServiceTest 
    {
        [TestMethod]
        public void  EncryptTest()
        {
            const string PATTERN = "Where Are You???";
            IHashService hashService = new AesService();

            var encrypted = hashService.EncryptToBase64UrlEncoded(PATTERN);
            var decrpyted = hashService.DecryptFromBase64UrlEncoded(encrypted);
            Assert.AreEqual(PATTERN,  decrpyted);
        }
    }
}
