using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PanelBoard.Web.Areas.Teacher.Controllers
{
    using Data.Services;
    using Data.ViewModels;
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class PortalController : Controller
    {
        private readonly ITeacherService _teacherService;

        public PortalController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetStudents()
        {
            var students = await _teacherService.GetStudents();

            return new JsonResult(new JqueryDataTablesResult<StudentViewModel> { Data = students.ToEnumerable() });
        }
    }
    public class Students
    {
        public string Name { get; set; }
    }
}