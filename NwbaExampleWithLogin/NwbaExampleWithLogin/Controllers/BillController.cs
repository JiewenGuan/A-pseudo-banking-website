using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NwbaExample.Data;
using NwbaExample.Models;
using NwbaExample.Utilities;
using NwbaExample.ViewModels;
using NwbaExampleWithLogin.Attributes;

namespace NwbaExample.Controllers
{
    [AuthorizeCustomer]
    public class BillController : Controller
    {
        private readonly NwbaContext _context;

        // ReSharper disable once PossibleInvalidOperationException
        private int CustomerID => HttpContext.Session.GetInt32(nameof(Customer.CustomerID)).Value;

        public BillController(NwbaContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            Customer customer = await _context.Customers.FindAsync(CustomerID);
            var bills = new List<Bill>();
            foreach (Account account in customer.Accounts)
                bills.AddRange(account.Bills);

            return View(bills.OrderBy(x=>x.Status));
        }

        public async Task<IActionResult> Create()
        {
            return View(
                new BillViewModel
                {
                    Customer = await _context.Customers.FindAsync(CustomerID),
                    Payees = _context.Payees.OrderBy(x => x.PayeeID).ToList(),
                    ScheduleDate = DateTime.Now
                });
        }
        [HttpPost]
        public async Task<IActionResult> Create(BillPeriod period, int fromAccount, int toPayee, decimal amount, DateTime scheduleDate)
        {
            BillViewModel retVM = new BillViewModel
            {
                Customer = await _context.Customers.FindAsync(CustomerID),
                Payees = _context.Payees.OrderBy(x => x.PayeeID).ToList(),
                ScheduleDate = DateTime.Now
            };
            Account account = await _context.Accounts.FindAsync(fromAccount);
            Payee payee = await _context.Payees.FindAsync(toPayee);
            if (payee is null)
                ModelState.AddModelError(nameof(toPayee), "Choose a valid Payee.");
            if (account is null)
                ModelState.AddModelError(nameof(fromAccount), "Choose a valid Account.");
            if (amount <= 0)
                ModelState.AddModelError(nameof(amount), "Amount must be positive.");
            if (amount.HasMoreThanTwoDecimalPlaces())
                ModelState.AddModelError(nameof(amount), "Amount cannot have more than 2 decimal places.");
            if (scheduleDate < DateTime.Now)
                ModelState.AddModelError(nameof(scheduleDate), "Cannot go back in time.");
            if (!ModelState.IsValid)
                return View(retVM);
            account.AddBill(period, payee, amount, scheduleDate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Success), new { message = nameof(Create) });
            //todo: make success page shared
        }
        public async Task<IActionResult> Edit(int id)
        {
            Bill bill = await _context.Bills.FindAsync(id);
            if (bill == null)
                return NotFound();
            return View(
                new BillViewModel
                {
                    BillID = id,
                    Customer = await _context.Customers.FindAsync(CustomerID),
                    Payees = _context.Payees.OrderBy(x => x.PayeeID).ToList(),
                    FromAccount = bill.Account,
                    ToPayee = bill.Payee,
                    Amount = bill.Amount,
                    Period = bill.Period,
                    ScheduleDate = bill.ScheduleDate
                });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, BillPeriod period, int fromAccount, int toPayee, decimal amount, DateTime scheduleDate)
        {
            Bill bill = await _context.Bills.FindAsync(id);
            Account account = await _context.Accounts.FindAsync(fromAccount);
            Payee payee = await _context.Payees.FindAsync(toPayee);

            if (bill == null)
                ModelState.AddModelError(nameof(toPayee), "Choose a valid Bill.");
            if (payee is null)
                ModelState.AddModelError(nameof(toPayee), "Choose a valid Payee.");
            if (account is null)
                ModelState.AddModelError(nameof(fromAccount), "Choose a valid Account.");
            if (amount <= 0)
                ModelState.AddModelError(nameof(amount), "Amount must be positive.");
            if (amount.HasMoreThanTwoDecimalPlaces())
                ModelState.AddModelError(nameof(amount), "Amount cannot have more than 2 decimal places.");
            if (scheduleDate < DateTime.Now)
                ModelState.AddModelError(nameof(scheduleDate), "Cannot go back in time.");
            BillViewModel retVM = new BillViewModel
            {
                Customer = await _context.Customers.FindAsync(CustomerID),
                Payees = _context.Payees.OrderBy(x => x.PayeeID).ToList(),
                FromAccount = account,
                ToPayee = payee,
                Amount = amount,
                Period = period,
                ScheduleDate = scheduleDate
            };
            if (!ModelState.IsValid)
                return View(retVM);
            bill.Update(period, account, payee, amount, scheduleDate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Success), new { message = nameof(Edit) });
            //todo: make success page shared
        }
        public IActionResult Success(string message)
        {
            ViewData["Message"] = message;
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await _context.Bills.FindAsync(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill != null)
                bill.Deactivate();
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}