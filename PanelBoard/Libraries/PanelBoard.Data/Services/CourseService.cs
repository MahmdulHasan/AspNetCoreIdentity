using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PanelBoard.Data.ViewModels;
using AutoMapper;
using System.Linq;
namespace PanelBoard.Data.Services
{
    
    using Data.UnitOfWork;
    using Data.Entities;
    using Data.ViewModels;

    public class CourseService
         : ICourseService
    {
        private CourseUnitOfWork _courseUniOfWork;

        public CourseService(CourseUnitOfWork course)
        {
            _courseUniOfWork = course;
        }
        public async Task<IEnumerable<CourseViewModel>> GetAllCourses()
        {
            var courses =  await _courseUniOfWork.CourseRepository.GetAll();

            var vcourses =  courses.OrderByDescending(o => o.Id).Select(s => new CourseViewModel
            {
                Id = s.Id,
                Name = s.Name
            });

            return vcourses;
        }

        public async Task<int> AddCourse(Course course)
        {
           

           var status = await _courseUniOfWork.CourseRepository.Add(course);

           return await _courseUniOfWork.Save();

        }
    }
}
