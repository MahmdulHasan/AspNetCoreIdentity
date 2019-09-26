using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PanelBoard.Membership.Entities;
using PanelBoard.Membership.ViewModels;

namespace PanelBoard.Membership.Services
{
    using Managers;
    using Helpers;
    public class AccountService
         : IAccountService
    {
        
        private readonly LoginTaskHelper _loginTaskHelper;
        private readonly RegistrationTaskHelper _registrationTaskHelper;
        private readonly LogoutTaskHelper _logoutTaskHelper;
       

        public User LoggedInUser
            => _loginTaskHelper.LoggedInUser;

        public IReadOnlyCollection<AccountRole> Roles { get; set; }

        public AccountService(
            AaaDbContext context,
            UserManager uManager,
            RoleManager rManager,
            SignInManager sManager)
        {
            _loginTaskHelper = new LoginTaskHelper(context, uManager, rManager, sManager);
            _registrationTaskHelper = new RegistrationTaskHelper(context, uManager);
            _logoutTaskHelper = new LogoutTaskHelper(context, sManager);
            
        }

        public Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            var result = _loginTaskHelper.ExecuteTaskAsync(model);
            Roles = _loginTaskHelper.Roles;
            return result;
        }

        public Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            return _registrationTaskHelper.ExecuteTaskAsync(model);
        }

        public Task LogOutAsync()
        {
            return _logoutTaskHelper.ExcuteTaskAsync();
        }

    }
}
