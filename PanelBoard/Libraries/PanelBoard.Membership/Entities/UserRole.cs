using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership.Entities
{
    public class UserRole
               : IdentityUserRole<Guid>
    {

       
        public User User { get; set; }
        public Role Role { get; set; }

    

        
    }
}
