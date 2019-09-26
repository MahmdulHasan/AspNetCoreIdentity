using System;
using System.Collections.Generic;
using System.Text;
using PanelBoard.Data.Entities;
using System.Linq;
using System.Threading.Tasks;
namespace PanelBoard.Data.Services
{
    using Data.UnitOfWork;
    using Membership.Services;
    using Data.ViewModels;

    public class TeacherService
        : ITeacherService
    {
        private readonly StudentUnitOfWork _studentUnitOfWork;
        private readonly TeacherUnitOfWork _teacherUnitOfWork;
        private readonly IAccountService _accountService;
        private IList<string> _courseNames;
        public TeacherService(StudentUnitOfWork studentUnitOfWork, TeacherUnitOfWork teacherUnitOfWork, IAccountService service)
        {
            _studentUnitOfWork = studentUnitOfWork;
            _teacherUnitOfWork = teacherUnitOfWork;
            _accountService = service;
            _courseNames = new List<string>();
        }

        public async Task<IAsyncEnumerable<StudentViewModel>> GetStudents()
        {
            var teacher = await _teacherUnitOfWork.TeacherRepository.GetTeacherByUserId(_accountService.LoggedInUser.Id);

            var teacherCourses = _teacherUnitOfWork.TeacherCourseRepository.GetIndividualTeacherCourses(teacher.Id);

            foreach (var c in teacherCourses)
                _courseNames.Add(c.Course.Name);


            var studentsInCourses = await _studentUnitOfWork.StudentCourseRepository.GetStudentsByCourses(_courseNames);

            var students =  studentsInCourses.Select(s => new StudentViewModel
            {
                Name = s.Student.Name
            });

            return students.ToAsyncEnumerable();

        }
    }
}
