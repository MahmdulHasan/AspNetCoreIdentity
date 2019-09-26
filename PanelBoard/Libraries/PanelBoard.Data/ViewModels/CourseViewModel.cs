using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelBoard.Data.ViewModels
{
  public class CourseViewModel
  {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Course Name", Prompt = "Enter course name")]
        public string Name { get; set; }
  }
}
