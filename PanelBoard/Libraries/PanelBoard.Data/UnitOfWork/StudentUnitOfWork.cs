using PanelBoard.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.UnitOfWork
{
    public class StudentUnitOfWork
            : UnitOfWork<PanelDbContext>
    {
        public StudentRepository StudentRepository;
        public CourseRepository CourseRepository;
        public StudentCourseRepository StudentCourseRepository;
        public StudentUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            StudentRepository = new StudentRepository(_DbContext);
            CourseRepository = new CourseRepository(_DbContext);
            StudentCourseRepository = new StudentCourseRepository(_DbContext);


        }
    }
}
