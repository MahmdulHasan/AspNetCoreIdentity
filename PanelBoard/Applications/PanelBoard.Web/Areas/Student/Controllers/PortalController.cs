using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PanelBoard.Web.Areas.Student.Controllers
{
    using Data.Services;
    using Data.ViewModels;
    using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;

    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class PortalController : Controller
    {
        private readonly IStudentService _studentService;

        public PortalController(IStudentService service)
        {
            _studentService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCourse()
        {

            var courses = await _studentService.GetCourses();
            
           
            return new JsonResult(new JqueryDataTablesResult<CourseViewModel>{ Data = courses.ToEnumerable()});
        }
    }

  
}