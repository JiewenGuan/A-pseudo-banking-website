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
        public int BadAttempt { get; set; }
        public DateTime lastBadLogin { get; set; }
        //Nav
        public virtual Customer Customer { get; set; }

        public void NewPassword(string comment)
        {
            PasswordHash = PBKDF2.Hash(comment);
            ModifyDate = DateTime.Now;
        }


        public bool Verify(string password)
        {
            if ((DateTime.Now - lastBadLogin).TotalMinutes < 1 && BadAttempt > 2)
                return false;

            if (PBKDF2.Verify(PasswordHash, password))
            {
                BadAttempt = 0;
                return true;
            }
            else
            {
                BadAttempt += 1;
                lastBadLogin = DateTime.Now;
                return false;
            }
        }
        public void Lock()
        {
            BadAttempt = 3;
            lastBadLogin = DateTime.Now;
        }
        public void Unlock()
        {
            BadAttempt = 0;
        }
    }
}
