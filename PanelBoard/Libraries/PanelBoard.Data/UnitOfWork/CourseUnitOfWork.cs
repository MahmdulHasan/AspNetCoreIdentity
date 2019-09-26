using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.UnitOfWork
{
    using Data.Repository;
    public class CourseUnitOfWork
        : UnitOfWork<PanelDbContext>
    {
        public CourseRepository CourseRepository;
        public CourseUnitOfWork(string connectionString, string migrationAssemblyName)
           : base(connectionString, migrationAssemblyName)
        {
            
            CourseRepository = new CourseRepository(_DbContext);
        }
    }
}
