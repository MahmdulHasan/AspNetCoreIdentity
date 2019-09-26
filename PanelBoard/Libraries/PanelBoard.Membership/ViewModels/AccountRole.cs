using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership.ViewModels
{
    public class AccountRole
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public AccountRole()
        {

        }

        public AccountRole(int id, string role)
        {
            Id = id;
            Role = role;
        }
    }
}
