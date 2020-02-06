using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NwbaExample.Models;

namespace NwbaExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        public IActionResult Except()
        {
            throw new NotImplementedException();
        }
        public IActionResult StatusCode(int? code = null)
        {
            return View(code);
        }
    }
}
