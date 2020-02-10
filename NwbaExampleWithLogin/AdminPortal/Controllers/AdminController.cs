using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminPortal.Models;
using AdminPortal.Web.Helper;
using Newtonsoft.Json;
using AdminPortal.Attributes;

namespace AdminPortal.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
             var response = await AdminApi.InitializeClient().GetAsync("user");

             if (!response.IsSuccessStatusCode)
                 throw new Exception();

             // Storing the response details recieved from web api.
             var result = response.Content.ReadAsStringAsync().Result;

             // Deserializing the response recieved from web api and storing into a list.
             var Customers = JsonConvert.DeserializeObject<List<Customer>>(result);

             return View(Customers);
        }
    }
}