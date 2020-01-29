using SimpleHashing;
using System;
using System.ComponentModel.DataAnnotations;

namespace NwbaExample.Models
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
        //Nav
        public virtual Customer Customer { get; set; }

        public void NewPassword(string comment)
        {
            PasswordHash = PBKDF2.Hash(comment);
        }
    }
}
