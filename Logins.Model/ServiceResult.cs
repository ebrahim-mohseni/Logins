using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logins.Model
{
    public class ServiceResult <T>
    {
        public T Data { get; set; }
        public bool HasError { get; set; } = false;
        public string Message { get; set; } = string.Empty;

    }
}
