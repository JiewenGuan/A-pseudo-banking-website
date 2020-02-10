using System;
using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models
{
    public class Login
    {
        [Key, Required, StringLength(50)]
        [Display(Name = "User ID")]
        public string LoginID { get; set; }
        [Required, StringLength(64)]
        public string PasswordHash { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public int BadAttempt { get; set; }
        public DateTime lastBadLogin { get; set; }
        //Nav
        public virtual Customer Customer { get; set; }

    }
}
