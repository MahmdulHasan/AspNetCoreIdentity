using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelBoard.Membership.ViewModels
{
   public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name", Prompt = "Enter username")]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter Password")]
        public string Password { get; set; }
    }
}
