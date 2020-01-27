using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NwbaExample.Models
{
    public enum AccountType
    {
        Saving = 1,
        Checking = 2,
    }

    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Account Number")]
        public int AccountNumber { get; set; }

        [Display(Name = "Type")]
        public AccountType AccountType { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
        public virtual List<Bill> Bills { get; set; }

        public bool AddTransaction(TransactionType type, Account destAccount, decimal amount, string comment)
        {
            decimal serviceCharge = 0m;
            if (type == TransactionType.Deposit)
            {
                Credit(amount);
            }
            else
            {
                if (type == TransactionType.Withdraw)
                {
                    serviceCharge = 0.1m;
                    if (!Debit(amount + serviceCharge))
                        return false;
                }
                if (type == TransactionType.Transfer)
                {
                    serviceCharge = 0.2m;
                    if (!Debit(amount + serviceCharge))
                        return false;
                    destAccount.AddTransaction(TransactionType.Deposit, null, amount,
                        string.Format("Transfer from Account:{0}, message:{1}", AccountNumber, comment));
                }
                if (serviceCharge > 0)
                    Transactions.Add(
                        new Transaction
                        {
                            TransactionType = TransactionType.ServiceCharge,
                            AccountNumber = this.AccountNumber,
                            Account = this,
                            Amount = serviceCharge,
                            Comment = string.Format("{0} service charge", type.ToString()),
                            TransactionTimeUtc = DateTime.UtcNow
                        });
            }
            Transactions.Add(
                new Transaction
                {
                    TransactionType = type,
                    AccountNumber = this.AccountNumber,
                    Account = this,
                    Amount = amount,
                    Comment = comment,
                    TransactionTimeUtc = DateTime.UtcNow
                });
            return true;
        }

        public void AddBill(BillPeriod period, Payee payee, decimal amount, DateTime scheduleDate)
        {
            Bill bill = new Bill
            {
                AccountNumber = this.AccountNumber,
                Account = this,
                PayeeID = payee.PayeeID,
                Payee = payee,
                Amount = amount,
                ScheduleDate = scheduleDate.Date,
                Period = period,
                ModifyDate = DateTime.Now
            };
            Bills.Add(bill);
            payee.Bills.Add(bill);
        }

        private void Credit(decimal amount)
        {
            this.Balance += amount;
        }
        private bool Debit(decimal amount)
        {
            if (Balance - (decimal)(200 * ((int)AccountType - 1)) < amount)
                return false;
            Balance -= amount;
            return true;
        }
    }
}
