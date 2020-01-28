using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NwbaExample.Models;
using System.ComponentModel.DataAnnotations;

namespace NwbaExample.ViewModels
{
    public class BillViewModel
    {
        public int BillID { get; set; }
        public Customer Customer { get; set; }
        public List<Payee> Payees { get; set; }
        [Required]
        public Account FromAccount { get; set; }
        [Required]
        public Payee ToPayee { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Schedule Date")]
        public DateTime ScheduleDate { get; set; }
        public BillPeriod Period { get; set; }
    }
}
