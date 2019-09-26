using Autofac;
using Microsoft.Extensions.Configuration;
using PanelBoard.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data
{
    using Seeds;
    using Services;
    public class PanelModule
          : Module
    {
        private string _connectionString;
        private string _migrationAssemblyName;
        private IConfiguration _configuration;

        public PanelModule(IConfiguration configuration, string connectionStringName, string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString(connectionStringName);
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PanelDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .SingleInstance();


            builder.RegisterType<StudentUnitOfWork>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();


            builder.RegisterType<TeacherUnitOfWork>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseUnitOfWork>()
              .WithParameter("connectionString", _connectionString)
              .WithParameter("migrationAssemblyName", _migrationAssemblyName)
              .InstancePerLifetimeScope();

            builder.RegisterType<StudentSeed>()
                .SingleInstance();

            builder.RegisterType<StudentService>()
                .As<IStudentService>();

            builder.RegisterType<TeacherService>()
                .As<ITeacherService>();

            builder.RegisterType<CourseService>()
                .As<ICourseService>();


            base.Load(builder);
        }
    }
}
