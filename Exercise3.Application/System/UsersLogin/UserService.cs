using Exercise3.Application.System.UsersLogin;
using Exercise3.Data.Entities;
using Exercise3.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Application.System.UsersLogin
{
    public class UserService : IUserService
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        // private readonly IConfiguration _config;

        public UserService(UserManager<Users> userManager,
          SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<string> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return ("Tài khoản không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.rememberme, true);
            if (!result.Succeeded)
            {
                return ("Đăng nhập không đúng");
            }
       //     var roles = await _userManager.GetRolesAsync(user);


            return Ok();
        }
    }
}