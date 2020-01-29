using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NwbaExample.Data;
using NwbaExample.Models;
using NwbaExample.Utilities;
using NwbaExampleWithLogin.Attributes;
using NwbaExample.ViewModels;
using System.Linq;
using X.PagedList;


namespace NwbaExample.Controllers
{
    [AuthorizeCustomer]
    public class CustomerController : Controller
    {
        private readonly NwbaContext _context;

        // ReSharper disable once PossibleInvalidOperationException
        private int CustomerID => HttpContext.Session.GetInt32(nameof(Customer.CustomerID)).Value;

        public CustomerController(NwbaContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            // Lazy loading.
            // The Customer.Accounts property will be lazy loaded upon demand.
            var customer = await _context.Customers.FindAsync(CustomerID);

            // OR
            // Eager loading.
            //var customer = await _context.Customers.Include(x => x.Accounts).
            //    FirstOrDefaultAsync(x => x.CustomerID == _customerID);

            return View(new TransactionViewModel
            {
                Customer = customer,
                Customers = _context.Customers.OrderBy(x => x.CustomerID).ToList()
            });
        }
        [HttpPost]
        public async Task<IActionResult> Index(TransactionType type, int fromAccount, int toAccount, decimal amount, string comment)
        {
            TransactionViewModel retVM = new TransactionViewModel
            {
                Customer = await _context.Customers.FindAsync(CustomerID),
                Customers = _context.Customers.OrderBy(x => x.CustomerID).ToList()
            };
            if (type == TransactionType.Transfer && toAccount == 0)
                ModelState.AddModelError(nameof(toAccount), "Destination Account cannot be null to transfer.");
            if (type != TransactionType.Transfer && toAccount != 0)
                ModelState.AddModelError(nameof(toAccount), "Destination Account must be null if not for transfer.");
            if (amount <= 0)
                ModelState.AddModelError(nameof(amount), "Amount must be positive.");
            if (amount.HasMoreThanTwoDecimalPlaces())
                ModelState.AddModelError(nameof(amount), "Amount cannot have more than 2 decimal places.");
            if (!string.IsNullOrEmpty(comment) && comment.Length > 254)
                ModelState.AddModelError(nameof(comment), "Comment too long!");
            if (fromAccount == toAccount)
                ModelState.AddModelError(nameof(toAccount), "Transfer to a different account.");
            if (!ModelState.IsValid)
                return View(retVM);

            Account destAccount = null;
            try
            {
                if (type == TransactionType.Transfer && toAccount != 0)
                    destAccount = await _context.Accounts.FindAsync(toAccount);
                var account = await _context.Accounts.FindAsync(fromAccount);
                if (account.AddTransaction(type, destAccount, amount, comment))
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Success), new { message = type.ToString() });
                }
                else
                {
                    ModelState.AddModelError(nameof(amount), string.Format("Insufficient funds, {0} failed", type.ToString()));
                    return View(retVM);
                }
            }
            catch(NullReferenceException e)
            {
                ModelState.AddModelError(nameof(type), string.Format("{0}, Stop Hacking the webpage!", e.Message));
                return View(retVM);
            }
        }
        public IActionResult Success(string message)
        {
            ViewData["Message"] = message;
            return View();
        }

        public async Task<IActionResult> Profile() => View(await _context.Customers.FindAsync(CustomerID));

        [HttpPost]
        public async Task<IActionResult> Profile(string name, string tfn, string address, string city, string state, string postCode, string phone)
        {
            Regex rgx = new Regex(@"^\(61\)-[1-9]{8}$");
            Customer retCustomer = await _context.Customers.FindAsync(CustomerID);
            if (string.IsNullOrEmpty(name))
                ModelState.AddModelError(nameof(name), "Arya? Is that you?");
            if (string.IsNullOrEmpty(phone))
                ModelState.AddModelError(nameof(phone), "Get a Number!");
            if (!string.IsNullOrEmpty(tfn) && tfn.Length != 11)
                ModelState.AddModelError(nameof(tfn), "TFN invalid");
            if (!rgx.IsMatch(phone))
                ModelState.AddModelError(nameof(phone), "Invalid Phone Number");
            if (!ModelState.IsValid)
                return View(retCustomer);
            retCustomer.Update( name,  tfn,  address,  city,  state,  postCode,  phone);
            HttpContext.Session.SetString(nameof(Customer.Name), name);
            _context.SaveChanges();
            return RedirectToAction(nameof(Success), new { message = "Update" });
        }

        public async Task<IActionResult> Statement(int accountOption = 0, int page = 1)
        {
            Customer retCustomer = await _context.Customers.FindAsync(CustomerID);
            IPagedList<Transaction> transactionList = null;
            if (accountOption != 0)
                transactionList = await retCustomer.Accounts.Find(x => x.AccountNumber == accountOption).Transactions.ToPagedListAsync(page, 4);
            StatementViewModel ret = new StatementViewModel
            {
                Customer = retCustomer,
                AccountOption = accountOption,
                Page = transactionList
            };

            return View(ret);
        }
        public IActionResult Password() => View(new TransactionViewModel { Comment = ""});

        [HttpPost]
        public async Task<IActionResult> Password(string comment)
        {
            if (string.IsNullOrEmpty(comment) || comment.Length < 6)
                ModelState.AddModelError(nameof(comment), "Password too short.");
            if (string.IsNullOrEmpty(comment) || comment.Length > 50)
                ModelState.AddModelError(nameof(comment), "Password too Long.");
            if (!ModelState.IsValid)
                return View(new TransactionViewModel { Comment = "" });
            _context.Logins.First(x => x.CustomerID == CustomerID).NewPassword(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Success), new { message = "Update password" });
        }
    }
}
