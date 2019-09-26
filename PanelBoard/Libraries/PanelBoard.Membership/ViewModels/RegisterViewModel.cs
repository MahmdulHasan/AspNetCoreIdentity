using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelBoard.Membership.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "UserName", Prompt = "Enter UserName")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The passwords do not match.")]
        [Display(Name = "Confirm Password", Prompt = "Enter password again")]
        public string ConfirmPassword { get; set; }
    }
}
