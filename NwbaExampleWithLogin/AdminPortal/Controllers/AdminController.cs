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
        public async Task<IActionResult> Transaction(int id=0)
        {
            ViewBag.UserId = id;
            string link = "";
            if (id != 0)
                link = id.ToString();
            var response = await AdminApi.InitializeClient().GetAsync("transaction/" + link);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            // Storing the response details recieved from web api.
            var result = response.Content.ReadAsStringAsync().Result;

            // Deserializing the response recieved from web api and storing into a list.
            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(result);

            return View(transactions);
        }
        public async Task<IActionResult> Bills(int id)
        {
            var response = await AdminApi.InitializeClient().GetAsync("payment/" + id.ToString());

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            // Storing the response details recieved from web api.
            var result = response.Content.ReadAsStringAsync().Result;

            // Deserializing the response recieved from web api and storing into a list.
            var bills = JsonConvert.DeserializeObject<List<Bill>>(result);

            return View(bills);
        }
        public async Task<IActionResult> BlockBillAsync(int id)
        {
            var response = await AdminApi.InitializeClient().GetAsync($"payment/block/" + id.ToString());
            if (!response.IsSuccessStatusCode)
                throw new Exception();
            else
                return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UnBlockBillAsync(int id)
        {
            var response = await AdminApi.InitializeClient().GetAsync($"payment/unblock/" + id.ToString());
            if (!response.IsSuccessStatusCode)
                throw new Exception();
            else
                return RedirectToAction(nameof(Index));
        }
    }
}