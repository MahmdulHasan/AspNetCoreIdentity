using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelBoard.Data.ViewModels
{
   public class StudentViewModel
    {
        [Required]
        [Display(Name = "Course Name", Prompt = "Enter course name")]
        public string Name { get; set; }
    }
}
