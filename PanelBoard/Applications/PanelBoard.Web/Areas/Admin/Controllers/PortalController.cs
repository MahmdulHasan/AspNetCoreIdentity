using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBoard.Data.ViewModels;
namespace PanelBoard.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using Data.Services;
    using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
    using PanelBoard.Data.Entities;

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class PortalController : Controller
    {

        private readonly ICourseService _courseService;
      
      
        public PortalController(ICourseService student)
        {
            _courseService = student;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
           
            return View();
        }

        public IActionResult DisplayCourses()
        {
            return View();
        }

        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetAllCourses();

            return new JsonResult(new JqueryDataTablesResult<CourseViewModel> { Data = courses });
        }

        [HttpPost]
        public async Task <IActionResult> AddCourse(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

           var course = Mapper.Map<Course>(viewModel);

           var status=  await _courseService.AddCourse(course);

            return View("DisplayCourses");
        }


    }
}