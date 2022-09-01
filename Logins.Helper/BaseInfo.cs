using System.Security.Cryptography;
using System.Text;

namespace Logins.Helper
{
    public class BaseInfo
    {
        public static string ConnectionString { get; set; } = string.Empty;
        public static string SqlUserName
        {
            get { return "sa"; }
        }

        public static string SqlPassword
        {
            get { return "webmaster"; }
        }

    }
}