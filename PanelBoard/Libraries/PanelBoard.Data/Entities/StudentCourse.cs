using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Entities
{
  public  class StudentCourse
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
