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
    public class BillPay
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BillPayID { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
        [Required]
        public int PayeeID { get; set; }
        public virtual Payee Payee { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Required]
        public DateTime ScheduleDate { get; set; }
        [Required]
        public BillPeriod Period { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
    }
}
