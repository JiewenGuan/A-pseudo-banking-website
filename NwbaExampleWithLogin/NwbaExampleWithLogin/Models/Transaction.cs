using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NwbaExample.Models
{
    public enum TransactionType
    {
        Deposit = 1,
        Withdraw = 2,
        Transfer = 3,
        ServiceCharge = 4,
        BillPay = 5
    }

    public class Transaction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransactionID { get; set; }
        [Required]
        public TransactionType TransactionType { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }

        [ForeignKey("DestinationAccount")]
        public int? DestinationAccountNumber { get; set; }
        public virtual Account DestinationAccount { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }
        [Required]
        public DateTime TransactionTimeUtc { get; set; }
    }
}
