using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace PanelBoard.Membership.Helpers
{
    using Managers;
    using Entities;
    using ViewModels;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    internal class LoginTaskHelper
    {
        private readonly AaaDbContext _context;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly SignInManager _signInManager;

        public User LoggedInUser { get; private set; }

        private IList<AccountRole> _Roles { get; set; }
        public IReadOnlyCollection<AccountRole> Roles { get => _Roles as IReadOnlyCollection<AccountRole>; }

        public LoginTaskHelper(
            AaaDbContext context,
            UserManager uManager,
            RoleManager rManager,
            SignInManager sManager)
        {
            _context = context;
            _userManager = uManager;
            _roleManager = rManager;
            _signInManager = sManager;
            _Roles = new List<AccountRole>();
        }

        public async Task<SignInResult> ExecuteTaskAsync(LoginViewModel model)
        {
            _Roles = new List<AccountRole>();

            var user = await _userManager.FindByNameAsync(model.Username);
            var roles = await _userManager.GetRolesAsync(user);

            if (user != null)
                LoggedInUser = user;

            foreach( var role in roles)
            {
                var userInRole = _roleManager.FindByNameAsync(role).GetAwaiter().GetResult();

                if (userInRole != null)
                    _Roles.Add(Mapper.Map<AccountRole>(userInRole));
            }
              
          
           

            var status = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);


            return status;
        }
    }
}
