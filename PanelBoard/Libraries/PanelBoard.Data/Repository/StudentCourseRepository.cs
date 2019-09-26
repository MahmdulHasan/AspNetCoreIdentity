using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PanelBoard.Data.Repository
{
    using Data.Entities;
    using System.Threading.Tasks;

    public class StudentCourseRepository
        : Repository<StudentCourse>
    {
        public StudentCourseRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<StudentCourse>> GetIndividualStudentCourses(Guid studentId)
        {

            return await _dbSet.Where(w => w.StudentId == studentId).Include(c => c.Course).ToListAsync();
        }


        public async Task<IEnumerable<StudentCourse>> GetStudentsByCourses(IEnumerable<string> courses)
        {
            return  await _dbSet.Where(w => courses.Contains(w.Course.Name)).Include(s => s.Student).ToListAsync();
        }

    }
}
