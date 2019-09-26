using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace PanelBoard.Membership.Helpers
{
    using Managers;
   

    internal class LogoutTaskHelper
    {
        private readonly AaaDbContext _context;
        private readonly SignInManager _signInManager;


        public LogoutTaskHelper(AaaDbContext context, SignInManager sManager)
        {
            _context = context;
            _signInManager = sManager;

        }

        public async Task ExcuteTaskAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
