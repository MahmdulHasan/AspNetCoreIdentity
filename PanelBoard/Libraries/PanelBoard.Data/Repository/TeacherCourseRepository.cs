using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace PanelBoard.Data.Repository
{
    using Data.Entities;
    using System.Linq;

    public class TeacherCourseRepository
        : Repository<TeacherCourse>
    {
        public TeacherCourseRepository(DbContext dbContext)
           : base(dbContext)
        {
        }

        public IEnumerable<TeacherCourse> GetIndividualTeacherCourses(Guid teacherId)
        {
              return _dbSet.Where(w => w.TeacherId == teacherId).Include(c => c.Course);
        }
    }
}
