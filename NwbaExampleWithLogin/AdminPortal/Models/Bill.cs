using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Models
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
        Blocked = 0,
        Overdue = 1,
        Active = 2,
        Deactivated = 3
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
        [Display(Name = "Schedule Date")]
        public DateTime ScheduleDate { get; set; }
        [Required]
        public BillPeriod Period { get; set; }
        [Required]
        public BillStatus Status { get; set; }
        [Required]
        [Display(Name = "Modify Date")]
        public DateTime ModifyDate { get; set; }
    }
}
