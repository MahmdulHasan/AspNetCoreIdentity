using PanelBoard.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.UnitOfWork
{
    public class TeacherUnitOfWork
            : UnitOfWork<PanelDbContext>
    {
        public StudentRepository StudentRepository;
        public TeacherRepository TeacherRepository;
        public TeacherCourseRepository TeacherCourseRepository;
        public TeacherUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            StudentRepository = new StudentRepository(_DbContext);
            TeacherRepository = new  TeacherRepository(_DbContext);
            TeacherCourseRepository = new TeacherCourseRepository(_DbContext);
        }
    }
}
