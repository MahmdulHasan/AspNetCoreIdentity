using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace PanelBoard.Data.Services
{
    using Data.UnitOfWork;
    using Membership.Services;
    using Data.ViewModels;

    public class StudentService
         : IStudentService
    {
        private readonly StudentUnitOfWork _studentUnitOfWork;
        private readonly IAccountService _accountService;
        private IEnumerable<CourseViewModel> courses;
        public StudentService(StudentUnitOfWork studentUnitOfWork, IAccountService service)
        {
            _studentUnitOfWork = studentUnitOfWork;
            _accountService = service;
            courses = new List<CourseViewModel>();
        }
        public async Task<IAsyncEnumerable<CourseViewModel>> GetCourses()
        {

            var  student = await _studentUnitOfWork.StudentRepository.GetStudentByUserId(_accountService.LoggedInUser.Id);

            if (student == null)
                return courses.ToAsyncEnumerable();

            var studentCourses = await _studentUnitOfWork.StudentCourseRepository.GetIndividualStudentCourses(student.Id);

            courses =  studentCourses.Select(s => new CourseViewModel
            {
                Name = s.Course.Name
            });

            return courses.ToAsyncEnumerable();
        }
    }
   
}
