using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PanelBoard.Membership;
using PanelBoard.Membership.Entities;
using PanelBoard.Membership.Managers;
using PanelBoard.Membership.ViewModels;

namespace PanelBoard.Web.Controllers
{
    using AutoMapper;
    using Membership.Services;
    public class AccountController : Controller
    {
        protected readonly IAccountService _AccountService;
        public AccountController(IAccountService accountService)
        {

            _AccountService = accountService;
        }

        private IActionResult CheckLoginStatus(LoginViewModel model, Microsoft.AspNetCore.Identity.SignInResult result, string returnUrl=null)
        {
            if (result.Succeeded)
                return RedirectToAppropiatePage(model, returnUrl);
            else
            {

            }

            return View("Login", model);
        }

        private IActionResult RedirectToAppropiatePage(LoginViewModel model, string returnUrl = null)
        {
            var controllerName = "Portal";
            string actionName = "Index";

            var userRoleId = _AccountService.Roles.Select(s=> s.Id);

            if (userRoleId.Any(ur=> ur == 1))
            {
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction(actionName, controllerName, new { area = "Admin" });
            }

            else if (userRoleId.Any(ur => ur == 2))
            {
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction(actionName, controllerName, new { area = "Student" });
            }

            else if (userRoleId.Any(ur => ur == 3))
            {
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction(actionName, controllerName, new { area = "Teacher" });
            }

            else
                return View("Login",model);


        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, [FromQuery] string returnUrl = null)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var result = await _AccountService.RegisterAsync(model);

                    if (result.Succeeded)
                    {
                        var loginViewModel = Mapper.Map<LoginViewModel>(model);
                        var loginStatus = await _AccountService.LoginAsync(loginViewModel);

                        return CheckLoginStatus(loginViewModel, loginStatus, returnUrl);
                    }

                }
                catch (Exception ex)
                {

                }

            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, [FromQuery] string returnUrl = null)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var loginStatus =  await _AccountService.LoginAsync(model);

                    return CheckLoginStatus(model,loginStatus,returnUrl);
                }
                catch (Exception ex)
                {
                    return View(model);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _AccountService.LogOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}