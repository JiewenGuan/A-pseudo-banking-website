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
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;

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
        public async Task<IActionResult> Transaction(int id = 0, DateTime? sDate = null, DateTime? eDate = null)
        {
            DateTime start = new DateTime(1, 1, 1), end = DateTime.Today.AddDays(1);
            if (sDate != null)
                start = (DateTime)sDate;
            if (eDate != null)
                end = (DateTime)eDate;
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
            transactions = transactions.Where(x => x.TransactionTimeUtc < end && x.TransactionTimeUtc > start).ToList();

            return View(transactions);
        }

        public async Task<IActionResult> Statistics(int id)
        {
            var response = await AdminApi.InitializeClient().GetAsync("transaction/" + id.ToString());

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            // Storing the response details recieved from web api.
            var result = response.Content.ReadAsStringAsync().Result;

            // Deserializing the response recieved from web api and storing into a list.
            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(result);

            return View(Bar(transactions));
        }
        private List<List<SimpleReportViewModel>> Bar(List<Transaction> transactions)
        {
            var ret = new List<List<SimpleReportViewModel>>();
            var incomeList = new List<SimpleReportViewModel>();
            var spendingList = new List<SimpleReportViewModel>();
            var pieList = new List<SimpleReportViewModel>();
            DateTime start = DateTime.Today.AddYears(-1);
            for (int i = 0; i < 12; i++)
            {
                decimal incoming = 0, outgoing = 0;
                foreach (Transaction t in transactions)
                    if (start.Year == t.TransactionTimeUtc.Year && start.Month == t.TransactionTimeUtc.Month)
                    {
                        if (t.TransactionType == TransactionType.Deposit)
                            incoming += t.Amount;
                        else
                            outgoing += t.Amount;
                    }
                incomeList.Add(new SimpleReportViewModel
                {
                    DimensionOne = start.ToString("yyyy/MMMM"),
                    Quantity = incoming
                });
                spendingList.Add(new SimpleReportViewModel
                {
                    DimensionOne = start.ToString("yyyy/MMMM"),
                    Quantity = outgoing
                });
                start = start.AddMonths(1);
            }
            foreach(TransactionType type in (TransactionType[])Enum.GetValues(typeof(TransactionType)))
            {
                decimal amount = 0;
                foreach(Transaction transaction in transactions)
                    if (transaction.TransactionType == type)
                        amount += transaction.Amount;
                
                pieList.Add(new SimpleReportViewModel
                {
                    DimensionOne = type.ToString(),
                    Quantity = amount
                });
            }
           
            ret.Add(incomeList);
            ret.Add(spendingList);
            ret.Add(pieList);
            return ret;
        }

        public async Task<IActionResult> Bills(int id)
        {
            ViewBag.UserId = id;

            var response = await AdminApi.InitializeClient().GetAsync("payment/" + id.ToString());

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            // Storing the response details recieved from web api.
            var result = response.Content.ReadAsStringAsync().Result;

            // Deserializing the response recieved from web api and storing into a list.
            var bills = JsonConvert.DeserializeObject<List<Bill>>(result);

            return View(bills);
        }
        public async Task<IActionResult> BlockBill(int id, int user)
        {
            var response = await AdminApi.InitializeClient().GetAsync($"payment/block/" + id.ToString());
            if (!response.IsSuccessStatusCode)
                throw new Exception();
            else
                return RedirectToAction(nameof(Bills), new { id = user });
        }
        public async Task<IActionResult> UnBlockBill(int id, int user)
        {
            var response = await AdminApi.InitializeClient().GetAsync($"payment/unblock/" + id.ToString());
            if (!response.IsSuccessStatusCode)
                throw new Exception();
            else
                return RedirectToAction(nameof(Bills), new { id = user });
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var response = await AdminApi.InitializeClient().GetAsync($"user/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var result = response.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<Customer>(result);

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Customer customer)
        {
            if (id != customer.CustomerID)
                return NotFound();
            Regex rgx = new Regex(@"^\(61\)-[1-9]{8}$");
            if (string.IsNullOrEmpty(customer.Name))
                ModelState.AddModelError(nameof(customer.Name), "Arya? Is that you?");
            if (string.IsNullOrEmpty(customer.Phone))
                ModelState.AddModelError(nameof(customer.Phone), "Get a Number!");
            if (!string.IsNullOrEmpty(customer.Tfn) && customer.Tfn.Length != 11)
                ModelState.AddModelError(nameof(customer.Tfn), "TFN invalid");
            if (!rgx.IsMatch(customer.Phone))
                ModelState.AddModelError(nameof(customer.Phone), "Invalid Phone Number");
            if (ModelState.IsValid)
            {

                var response = await AdminApi.InitializeClient().GetAsync
                    ($"update/{id}?name={customer.Name}&tfn={customer.Tfn}&address={customer.Address}&city={customer.City}&state={customer.State}&postcode={customer.PostCode}&phone={customer.Phone}");




                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            return View(customer);
        }
    }
}