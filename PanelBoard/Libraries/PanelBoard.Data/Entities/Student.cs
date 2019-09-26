using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace PanelBoard.Data.Entities
{
    using Membership.Entities; 
   public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

       

       
    }
}
