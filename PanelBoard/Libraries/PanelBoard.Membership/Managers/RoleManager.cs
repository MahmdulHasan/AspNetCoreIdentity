using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PanelBoard.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership.Managers
{
    public class RoleManager
           : AspNetRoleManager<Role>
    {
        public RoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<AspNetRoleManager<Role>> logger, IHttpContextAccessor context)
            : base(store, roleValidators, keyNormalizer, errors, logger, context)
        {
        }
    }
}
