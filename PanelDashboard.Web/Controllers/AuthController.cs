using System;
using System.Security.Claims;
using System.Threading.Tasks;
using PanelDashboard.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelDashboard.Repo.Entities.Request;

namespace PanelDashboard.Web.Controllers
{
    public class AuthController : Controller
    {
        private LoginService loginService;
        public AuthController(LoginService loginService)
        {
            this.loginService = loginService;
        }
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm]AuthenticationEntities model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var credential = this.loginService.Authorize(model.Email, model.Password);
                    await HttpContext.SignInAsync(new ClaimsPrincipal(credential));
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return RedirectToAction("index", "dashboard");
                    }
                    return Redirect(model.ReturnUrl);
                }
                return View();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Email", e.Message);
                return View();
            }
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}