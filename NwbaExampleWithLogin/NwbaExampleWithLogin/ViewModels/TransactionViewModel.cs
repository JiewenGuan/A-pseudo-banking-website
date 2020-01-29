using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NwbaExample.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NwbaExample.ViewModels
{
    public class TransactionViewModel
    {
        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }
        [Display(Name ="Transaction Type")]
        [Required]
        public TransactionType Type { get; set; }
        [Required]
        [Display(Name = "Account")]
        public Account FromAccount { get; set; }
        [Display(Name = "Transfer to")]
        public Account ToAccount { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Comment { get; set; }
    }
}
