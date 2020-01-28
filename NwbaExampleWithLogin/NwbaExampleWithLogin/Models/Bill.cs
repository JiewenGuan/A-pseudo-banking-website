using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NwbaExample.Models
{
    public enum BillPeriod
    {
        Monthly = 1,
        Quarterly = 2,
        Annually = 3,
        OnceOff = 4
    }
    public enum BillStatus
    {
        Overdue = 1,
        Active = 2,
        Deactivated = 3
    }
    public class Bill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillID { get; set; }

        public void Exicute()
        {
            if (!Account.AddTransaction(TransactionType.BillPay, null, Amount, string.Format("Bill payment to {0}.", Payee.PayeeName)))
            {
                Status = BillStatus.Overdue;
                return;
            }
            switch (Period)
            {
                case BillPeriod.OnceOff:
                    Status = BillStatus.Deactivated;
                    break;
                case BillPeriod.Monthly:
                    ScheduleDate = ScheduleDate.AddMonths(1);
                    break;
                case BillPeriod.Quarterly:
                    ScheduleDate = ScheduleDate.AddMonths(3);
                    break;
                case BillPeriod.Annually:
                    ScheduleDate = ScheduleDate.AddYears(1);
                    break;
            }

            return;
        }

        [Required]
        [Display(Name = "Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
        [Required]
        [Display(Name = "Payee")]
        public int PayeeID { get; set; }
        public virtual Payee Payee { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Required]
        [Display(Name = "Schedule Date")]
        public DateTime ScheduleDate { get; set; }
        [Required]
        public BillPeriod Period { get; set; }
        [Required]
        public BillStatus Status { get; set; }
        [Required]
        [Display(Name = "Modify Date")]
        public DateTime ModifyDate { get; set; }

        public void Update(BillPeriod period, Account account, Payee payee, decimal amount, DateTime scheduleDate)
        {
            Period = period;
            Account = account;
            AccountNumber = account.AccountNumber;
            Payee = payee;
            PayeeID = payee.PayeeID;
            Amount = amount;
            ScheduleDate = scheduleDate;
            ModifyDate = DateTime.Now;
        }
        public void Deactivate()
        {
            Status = BillStatus.Deactivated;
        }
    }
}
