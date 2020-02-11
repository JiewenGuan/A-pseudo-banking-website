using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPortal.Models
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Range(1000,9999)]
        public int CustomerID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(11), Display(Name = "Tax File Number")]
        public string Tfn { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(4), Display(Name = "Post Code")]
        public string PostCode { get; set; }
        
        [Required, StringLength(15),RegularExpression(@"^\(61\)-[1-9]{8}$")]
        public string Phone { get; set; }
        //Nav
        public virtual List<Account> Accounts { get; set; }

        public virtual Login Login { get; set; }

       
      
        
    }
}
