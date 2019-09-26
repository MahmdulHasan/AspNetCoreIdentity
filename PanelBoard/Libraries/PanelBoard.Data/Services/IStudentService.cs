using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace PanelBoard.Data.Services
{
    using Data.ViewModels;
 

    public interface IStudentService
    {
        Task<IAsyncEnumerable<CourseViewModel>> GetCourses();
    }
}
