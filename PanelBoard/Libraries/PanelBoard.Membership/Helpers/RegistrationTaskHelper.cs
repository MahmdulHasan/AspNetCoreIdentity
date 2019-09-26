using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
namespace PanelBoard.Membership.Helpers
{
    using Managers;
    using ViewModels;
    using Entities;
    using System.Linq;
    using AutoMapper;

    public class RegistrationTaskHelper
    {
        private readonly AaaDbContext _context;
        private readonly UserManager _userManager;
      

        public RegistrationTaskHelper(AaaDbContext context, UserManager uManager)
        {
            _context = context;
            _userManager = uManager;
           
        }

        public async Task<IdentityResult> ExecuteTaskAsync(RegisterViewModel model)
        {

            IdentityResult result = null;
            var checkUserStatus = _context.Users.SingleOrDefault(u => u.UserName == model.UserName);

            if (checkUserStatus == null)
            {
                var user = Mapper.Map<User>(model);

                result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    user = await _userManager.FindByNameAsync(user.UserName);

                    return await _userManager.AddToRoleAsync(user, "Student");
                }
                else {
                }
            }
            return result;

         
        }



    }
}
