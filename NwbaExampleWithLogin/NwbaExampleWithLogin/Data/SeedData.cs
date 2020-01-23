using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using NwbaExample.Models;

namespace NwbaExample.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new NwbaContext(serviceProvider.GetRequiredService<DbContextOptions<NwbaContext>>());

            // Look for customers.
            if(context.Customers.Any())
                return; // DB has already been seeded.
            const string format = "dd/MM/yyyy hh:mm:ss tt";
            context.Customers.AddRange(
                new Customer
                {
                    CustomerID = 2100,
                    Name = "Matthew Bolger",
                    Tfn = "12345678910",
                    Address = "123 Fake Street",
                    City = "Melbourne",
                    State = "Victoria",
                    PostCode = "3000",
                    Phone = "(61)-12345678"
                },
                new Customer
                {
                    CustomerID = 2200,
                    Name = "Rodney Cocker",
                    Address = "456 Real Road",
                    City = "Melbourne",
                    PostCode = "3005",
                    Phone = "(61)-12345678"
                },
                new Customer
                {
                    CustomerID = 2300,
                    Name = "Shekhar Kalra",
                    Phone = "(61)-12345678"
                });

            context.Logins.AddRange(
                new Login
                {
                    LoginID = "12345678",
                    CustomerID = 2100,
                    PasswordHash = "YBNbEL4Lk8yMEWxiKkGBeoILHTU7WZ9n8jJSy8TNx0DAzNEFVsIVNRktiQV+I8d2",
                    ModifyDate = DateTime.ParseExact("19/12/2019 08:00:00 PM", format, null)

                },
                new Login
                {
                    LoginID = "38074569",
                    CustomerID = 2200,
                    PasswordHash = "EehwB3qMkWImf/fQPlhcka6pBMZBLlPWyiDW6NLkAh4ZFu2KNDQKONxElNsg7V04",
                    ModifyDate = DateTime.ParseExact("19/12/2019 08:00:00 PM", format, null)
                },
                new Login
                {
                    LoginID = "17963428",
                    CustomerID = 2300,
                    PasswordHash = "LuiVJWbY4A3y1SilhMU5P00K54cGEvClx5Y+xWHq7VpyIUe5fe7m+WeI0iwid7GE",
                    ModifyDate = DateTime.ParseExact("19/12/2019 08:00:00 PM", format, null)
                });

            context.Accounts.AddRange(
                new Account
                {
                    ModifyDate = DateTime.ParseExact("19/12/2019 08:00:00 PM", format, null),
                    AccountNumber = 4100,
                    AccountType = AccountType.Saving,
                    CustomerID = 2100,
                    Balance = 100
                },
                new Account
                {
                    ModifyDate = DateTime.ParseExact("19/12/2019 08:00:00 PM", format, null),
                    AccountNumber = 4101,
                    AccountType = AccountType.Checking,
                    CustomerID = 2100,
                    Balance = 500
                },
                new Account
                {
                    ModifyDate = DateTime.ParseExact("19/12/2019 08:00:00 PM", format, null),
                    AccountNumber = 4200,
                    AccountType = AccountType.Saving,
                    CustomerID = 2200,
                    Balance = 500.95m
                },
                new Account
                {
                    ModifyDate = DateTime.ParseExact("19/12/2019 08:00:00 PM", format, null),
                    AccountNumber = 4300,
                    AccountType = AccountType.Checking,
                    CustomerID = 2300,
                    Balance = 1250.50m
                });
            context.Payees.AddRange(
                new Payee
                {
                    PayeeName = "Telstra",
                    Phone = "(61)-45632178",
                    Address = "gpo 123 melbourne"
                },
                new Payee
                {
                    PayeeName = "payee2",
                    Phone = "(61)-45632178",
                    Address = "gpo 123 melbourne"
                }
                );
            const string openingBalance = "Opening balance";
            context.Transactions.AddRange(
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = openingBalance,
                    TransactionTimeUtc = DateTime.ParseExact("19/12/2019 08:00:00 PM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4101,
                    Amount = 500,
                    Comment = openingBalance,
                    TransactionTimeUtc = DateTime.ParseExact("19/12/2019 08:30:00 PM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4200,
                    Amount = 500.95m,
                    Comment = openingBalance,
                    TransactionTimeUtc = DateTime.ParseExact("19/12/2019 09:00:00 PM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4300,
                    Amount = 1250.50m,
                    Comment = "Opening balance",
                    TransactionTimeUtc = DateTime.ParseExact("19/12/2019 10:00:00 PM", format, null)
                });

            context.SaveChanges();
        }
    }
}
