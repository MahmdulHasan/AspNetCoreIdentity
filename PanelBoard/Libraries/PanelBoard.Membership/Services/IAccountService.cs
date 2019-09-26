using Microsoft.AspNetCore.Identity;
using PanelBoard.Membership.Entities;
using PanelBoard.Membership.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanelBoard.Membership.Services
{
   public interface IAccountService
    {
        User LoggedInUser { get; }
        IReadOnlyCollection<AccountRole> Roles { get; }
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);
        Task LogOutAsync();


    }
}
