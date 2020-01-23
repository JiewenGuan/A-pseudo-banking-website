using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NwbaExample.Models
{
    public class Payee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PayeeID { get; set; }
        [Required, StringLength(50)]
        public string PayeeName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(4)]
        public string PostCode { get; set; }

        [Required, StringLength(15), RegularExpression("^(61)-[1-9]{8}$")]
        public string Phone { get; set; }
        public virtual List<BillPay> Bills { get; set; }
    }
}
