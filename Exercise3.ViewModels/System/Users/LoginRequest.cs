using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.ViewModels.System.Users
{
    public class LoginRequest
    {
        public String UserName { get; set; }
        public String Password { get; set; }

        public bool rememberme { get; set; }
    }
}
