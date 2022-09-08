using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logins.Domain.Classes
{
    public class Lookup
    {
        public int LookupId { get; set; }
        public int LookupTypeId { get; set; }
        public string Caption { get; set; } = string.Empty;
    }
}
