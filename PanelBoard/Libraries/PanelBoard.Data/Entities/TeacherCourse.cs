using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Entities
{
  public  class TeacherCourse
    {
        public Guid TeacherId { get; set; }
        public Guid CourseId { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
