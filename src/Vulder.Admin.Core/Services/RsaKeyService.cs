using System;
using System.Security.Cryptography;
using System.Text;

namespace Vulder.Admin.Core.Services
{
    public class RsaKeyService
    {
        public (string, string) GetGeneratedRsaKeys()
        {
            using var rsa = RSA.Create(3077);
            return (Convert.ToBase64String(rsa.ExportRSAPublicKey()), 
                Convert.ToBase64String(rsa.ExportRSAPrivateKey()));
        }

        private static RSA GetRsa(string publicKey, string privateKey)
        {
            using var rsa = RSA.Create();
            rsa.ImportFromPem(publicKey);
            rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(privateKey), out _);
            
            return rsa;
        }

        public string GetHashedPassword(string publicKey, string privateKey,  string password)
        {
            using var rsa = GetRsa(publicKey, privateKey);
            var encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(password), RSAEncryptionPadding.OaepSHA512);
            
            return Convert.ToBase64String(encrypted);
        }

        public bool VerifyPassword(string publicKey, string privateKey, string encryptedPassword, string requestPassword)
        {
            try
            {
                using var rsa = GetRsa(publicKey, privateKey);
                var decrypt = rsa.Decrypt(Convert.FromBase64String(encryptedPassword), RSAEncryptionPadding.OaepSHA512);

                return Encoding.UTF8.GetString(decrypt) == requestPassword;
            }
            catch (CryptographicException)
            {
                return false;
            }
        }
    }
}