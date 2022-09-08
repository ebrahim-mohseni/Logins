using System.Security.Cryptography;
using System.Text;

namespace Logins.Helper
{
    public class BaseInfo
    {
        public static string ConnectionString { get; set; } = string.Empty;
        public static string Key { get { return "pt4InMor$$AZK&$$"; } }
    }
}