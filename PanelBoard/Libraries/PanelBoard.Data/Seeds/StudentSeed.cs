using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace PanelBoard.Data.Seeds
{
  using UnitOfWork;
  using Entities;
  public class StudentSeed
        : DataSeed
    {
        private readonly StudentUnitOfWork _studentUnitOfWork;
        private TeacherUnitOfWork _teacherUnitOfWork;
        private Student student1, student2;
        private Teacher teacher;
        private Guid _studentId1, _studentId2,_teacherId;


        public StudentSeed(StudentUnitOfWork studentUnitOfWork, TeacherUnitOfWork teacherUnitOfWork, PanelDbContext context)
            : base(context)
        {
            _studentUnitOfWork = studentUnitOfWork;
            _teacherUnitOfWork = teacherUnitOfWork;
            student1 = new Student();
            student2 = new Student();
            teacher = new Teacher();
            _studentId1= new Guid("E9F4D579-BD00-4D52-6CC1-08D72ED16B52");
            _studentId2 = new Guid("A78DAD5A-4174-4FE6-6F4F-08D72EE2F493"); 
            _teacherId = new Guid("1FF1F11E-774F-4819-6CC0-08D72ED16B52");

        }

        private void SeedStudentAsync(Student student, Guid studentId,string name, 
                            string sub1, string sub2, string sub3)
        {
             

            student.UserId = studentId;
            student.Name = name;

           
            student.StudentCourses = new List<StudentCourse>()
            {
                new StudentCourse()
                {
                   Student = student,
                   Course = new Course() { Name = sub1 }
                },
                 new StudentCourse()
                {
                   Student = student,
                   Course = new Course() { Name = sub2 }
                },
                  new StudentCourse()
                {
                   Student = student,
                   Course = new Course() { Name = sub3 }
                }
            };

           


           _studentUnitOfWork.StudentRepository.Add(student);
            

        }

        private void SeedTeacherAsync(Teacher teacher, Guid teacherId, string name,
                     string sub1, string sub2)
        {
            teacher.UserId = _teacherId;
            teacher.Name = "Jalal Uddin";



            teacher.TeacherCourses = new List<TeacherCourse>()
            {
                new TeacherCourse()
                {
                    Teacher = teacher,
                    Course = new Course(){Name= sub1}
                },
                new TeacherCourse()
                {
                    Teacher = teacher,
                    Course = new Course(){Name= sub2}
                }

            };

            _teacherUnitOfWork.TeacherRepository.Add(teacher);
            _teacherUnitOfWork.Save();
        }

        public void SeedSaveIntoDB()
        {
            _studentUnitOfWork.Save();
        }

        public override void SeedAsync()
        {
            if (!_studentUnitOfWork.StudentRepository.IsExist(_studentId1))
            {
                SeedStudentAsync(student1, _studentId1,"Mahmuduul Hasan","System Analysis","Database Design","Asp.net Core MVC");
                SeedSaveIntoDB();
            }
            if (!_studentUnitOfWork.StudentRepository.IsExist(_studentId2))
            {
               SeedStudentAsync(student2, _studentId2, "Mosiur Kazi","Compiler Design", "Data Communication", "Asp.net Core MVC");
               SeedSaveIntoDB();
            }

            if (!_teacherUnitOfWork.TeacherRepository.IsExist(_teacherId))
            {
                SeedTeacherAsync(teacher, _teacherId, "Jalal Uddin", "ASP.net Core MVC", "Software Development With PHP");
            }
        }
    }
}
