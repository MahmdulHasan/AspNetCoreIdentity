using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership.Entities
{
    public class Role
           : IdentityRole<Guid>, IEntity<Guid>
    {
        
        public Role()
            : base()
        {

        }

        public Role(string role)
            : base(role)
        {

        }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
