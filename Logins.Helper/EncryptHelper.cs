using System.Security.Cryptography;
using System.Text;

namespace Logins.Helper
{
    public static class EncryptHelper
    {
        private static readonly string Salt = "S0m3R@nd0mSalt";

        public static string PasswordHash(string password)
        {
            var provider = MD5.Create();
            string salt = "S0m3R@nd0mSalt";
            byte[] bytes = provider.ComputeHash(Encoding.UTF32.GetBytes(salt + password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public static string Encrypt(string decrypted)
        {
            byte[] data = Encoding.UTF32.GetBytes(decrypted);
            var md5 = new MD5CryptoServiceProvider();
            var tripleDEC = new TripleDESCryptoServiceProvider
            {
                Key = md5.ComputeHash(Encoding.UTF32.GetBytes(Salt)),
                Mode = CipherMode.ECB
            };
            ICryptoTransform transform = tripleDEC.CreateEncryptor();
            var result = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string encrypted)
        {
            byte[] data = Convert.FromBase64String(encrypted);
            var md5 = new MD5CryptoServiceProvider();
            var tripleDEC = new TripleDESCryptoServiceProvider
            {
                Key = md5.ComputeHash(Encoding.UTF32.GetBytes(Salt)),
                Mode = CipherMode.ECB
            };
            tripleDEC.Key = md5.ComputeHash(Encoding.UTF32.GetBytes(Salt));
            tripleDEC.Mode = CipherMode.ECB;
            ICryptoTransform transform = tripleDEC.CreateDecryptor();
            var result = transform.TransformFinalBlock(data, 0, data.Length);
            return Encoding.UTF32.GetString(result);
        }
    }
}
