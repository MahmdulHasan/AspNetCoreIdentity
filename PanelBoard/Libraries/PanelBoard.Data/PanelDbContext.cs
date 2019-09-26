using Microsoft.EntityFrameworkCore;
using PanelBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace PanelBoard.Data
{
    using Membership.Entities;
    public class PanelDbContext
        : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public PanelDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName));
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Ignore<UserRole>();
             modelBuilder.Ignore<User>();

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Student>()
                .HasMany(sc => sc.StudentCourses)
                .WithOne(s => s.Student)
                .HasForeignKey(sk => sk.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(sc => sc.StudentCourses)
                .WithOne(c => c.Course)
                .HasForeignKey(cf => cf.CourseId);

            modelBuilder.Entity<TeacherCourse>()
               .HasKey(tc => new { tc.CourseId, tc.TeacherId });

            modelBuilder.Entity<Course>()
                .HasMany(tc => tc.TeacherCourses)
                .WithOne(c => c.Course)
                .HasForeignKey(ck => ck.CourseId);

            modelBuilder.Entity<Teacher>()
                .HasMany(tc => tc.TeacherCourses)
                .WithOne(t => t.Teacher)
                .HasForeignKey(tf => tf.TeacherId);

            
           

           
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<TeacherCourse> TeacherCourses { get; set; }


    }
}
