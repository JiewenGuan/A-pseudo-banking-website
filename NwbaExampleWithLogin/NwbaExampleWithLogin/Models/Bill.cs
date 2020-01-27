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
    public class Bill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillID { get; set; }
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
        [DataType(DataType.Date)]
        [Display(Name = "Schedule Date")]
        public DateTime ScheduleDate { get; set; }
        [Required]
        public BillPeriod Period { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }

        internal void Update(BillPeriod period, Account account, Payee payee, decimal amount, DateTime scheduleDate)
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
    }
}
