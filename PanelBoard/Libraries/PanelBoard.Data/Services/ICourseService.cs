using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanelBoard.Data.Services
{
    using Data.ViewModels;
    using Data.Entities;
   public interface ICourseService
    {
        Task<IEnumerable<CourseViewModel>> GetAllCourses();
        Task<int> AddCourse(Course course);
    }
}
