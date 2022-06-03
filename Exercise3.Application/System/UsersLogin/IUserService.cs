using Exercise3.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Application.System.UsersLogin
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

    }
}
