using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BfiBaseTemplate.Web.Controllers
{
    public class VerificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify([FromForm] string Otp)
        {
            try
            {
                if (Otp == "1234")
                {
                    return Json(new { status = "success", message = "" });
                }
                throw new ArgumentException("OTP yang anda input tidak valid");
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message });
            }
        }
        public IActionResult CreatePassword()
        {
            return PartialView("_CreatePassword");
        }
    }
}