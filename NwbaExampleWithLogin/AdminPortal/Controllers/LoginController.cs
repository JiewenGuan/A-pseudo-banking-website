using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers
{
    [Route("/placeholder/secureLogin")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string loginID="", string password="")
        {
            if (loginID == "admin" && password == "admin")
            {
                HttpContext.Session.SetString("admin", "admin");
                return RedirectToAction("index", "home");
            }
            else
            {
                ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
                return View();
            }
        }
        [Route("LogoutNow")]
        public IActionResult Logout()
        {
            // Logout customer.
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}