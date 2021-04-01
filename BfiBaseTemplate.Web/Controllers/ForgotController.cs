using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BfiBaseTemplate.Web.Controllers
{
    public class ForgotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePassword()
        {
            return RedirectToAction("login", "auth");
        }
    }
}