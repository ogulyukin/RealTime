using System;
using System.Security.Cryptography;
using System.Text;

namespace SaveSystem.FileSaverSystem
{
    public sealed class AesEncryptionProvider
    {
        private const string Key = "A60B1812FE5E7AA200BA9CFC94E4E8B0"; //set any string of 32 chars
        private const string Iv = "1234967887654111"; //set any string of 16 chars
        private readonly AesCryptoServiceProvider _aesCryptoProvider;

        public AesEncryptionProvider()
        {
            _aesCryptoProvider = new AesCryptoServiceProvider();
            _aesCryptoProvider.BlockSize = 128;
            _aesCryptoProvider.KeySize = 256;
            _aesCryptoProvider.Key = Encoding.ASCII.GetBytes(Key);
            _aesCryptoProvider.IV = Encoding.ASCII.GetBytes(Iv);
            _aesCryptoProvider.Mode = CipherMode.CBC;
            _aesCryptoProvider.Padding = PaddingMode.PKCS7;
        }
        
        public string AesEncryption(string inputData)
        {
            var txtByteData = Encoding.ASCII.GetBytes(inputData);
            var cryptoTransform = _aesCryptoProvider.CreateEncryptor(_aesCryptoProvider.Key, _aesCryptoProvider.IV);
 
            var result = cryptoTransform.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
            return Convert.ToBase64String(result);
        }
        
        public string AesDecryption(string inputData)
        {
            var txtByteData = Convert.FromBase64String(inputData);
            var cryptoTransform = _aesCryptoProvider.CreateDecryptor();
 
            var result = cryptoTransform.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
            return Encoding.ASCII.GetString(result);
        }
        
    }
}
