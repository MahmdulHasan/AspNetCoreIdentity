using Microsoft.AspNetCore.Identity;
using PanelBoard.Membership.Entities;
using PanelBoard.Membership.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanelBoard.Membership
{
    using Seeds;
    public class AaaSeed
            : IdentitySeed
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        private readonly User _adminUser, _teacherUser, _studentUser;
        private readonly Role _adminRole, _teacherRole, _studentRole;

        public AaaSeed(UserManager userManager, RoleManager roleManager, AaaDbContext context)
            : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            _adminUser = new User("admin");
            _teacherUser = new User("jalaluddin");
            _studentUser = new User("mahmudulhasan");
       
            _adminRole = new Role("Administrator");
            _teacherRole = new Role("Teacher");
            _studentRole = new Role("Student");
            
        }

        private async Task<bool> CheckAndCreateRoleAsync(Role role)
        {
            if ((await _roleManager.FindByNameAsync(role.Name)) == null)
            {
                var result = await _roleManager.CreateAsync(role);
                return result.Succeeded;
            }
            return true;
        }

        private async Task SeedIdentityUsersAsync()
        {
            IdentityResult result = null;
            if ((await _userManager.FindByNameAsync(_adminUser.UserName.ToUpper())) == null)
            {
                result = await _userManager.CreateAsync(_adminUser, "@Adminbatch01");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRoleAsync(_adminRole))
                    {
                        await _userManager.AddToRoleAsync(_adminUser, _adminRole.Name);
                    }
                }
            }

            if ((await _userManager.FindByNameAsync(_teacherUser.UserName.ToUpper())) == null)
            {
                result = await _userManager.CreateAsync(_teacherUser, "@Teacherbatch01");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRoleAsync(_teacherRole))
                        await _userManager.AddToRoleAsync(_teacherUser, _teacherRole.Name);
                }
            }

            if ((await _userManager.FindByNameAsync(_studentUser.UserName.ToUpper())) == null)
            {
                result = await _userManager.CreateAsync(_studentUser, "@Studentbatch01");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRoleAsync(_studentRole))
                        await _userManager.AddToRoleAsync(_studentUser, _studentRole.Name);
                }
            }

        }

        public override async Task SeedAsync()
        {
            await SeedIdentityUsersAsync();
        }
    }
}
