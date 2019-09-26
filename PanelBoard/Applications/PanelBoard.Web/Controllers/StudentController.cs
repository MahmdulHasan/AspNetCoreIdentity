using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBoard.Data.UnitOfWork;
namespace PanelBoard.Web.Controllers
{
    using Data.Entities;

    public class StudentController : Controller
    {

        private readonly StudentUnitOfWork _studentUnitOfWork;
        public StudentController(StudentUnitOfWork studentUnitOfWork)
        {
            _studentUnitOfWork = studentUnitOfWork;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult GetStudentCourse()
        {
          
            return View();
        }

        
    }

    public class SCourses
    {
        public string Name { get; set; }
    }
}