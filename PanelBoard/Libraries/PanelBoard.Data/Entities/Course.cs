using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PanelBoard.Data.Entities
{
  public  class Course
    {

        public Course()
        {

        }
        public Course(string name)
        {
            Name = name;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}
