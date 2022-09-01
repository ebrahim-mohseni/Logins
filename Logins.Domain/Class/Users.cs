using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logins.Domain.Class
{
    public class Users
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int UserTypeId { get; set; }
        public string Profile { get; set; } = string.Empty;
        public DateTime SignupDate { get; set; }
        public bool Locked { get; set; }
    }
}
