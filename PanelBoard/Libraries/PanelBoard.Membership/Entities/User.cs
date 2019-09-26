using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership.Entities
{
    public class User
          : IdentityUser<Guid>, IEntity<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public User()
            : base()
        {

        }

        public User(string userName)
            : base(userName)
        {

        }


    }
}
