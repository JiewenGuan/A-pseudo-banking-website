using Microsoft.EntityFrameworkCore;
using NwbaExample.Models;

namespace NwbaExample.Data
{
    public class NwbaContext : DbContext
    {
        public NwbaContext(DbContextOptions<NwbaContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Payee> Payees { get;set;}
        public DbSet<BillPay> BillPays {get;set;}

protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().HasOne<Login>(l => l.Login)
                .WithOne(l => l.Customer).HasForeignKey<Login>(l => l.CustomerID);
            builder.Entity<Account>().HasOne<Customer>(a => a.Customer)
                .WithMany(c => c.Accounts).HasForeignKey(a => a.CustomerID);
            builder.Entity<BillPay>().HasOne<Account>(b => b.Account).WithMany(a => a.Bills)
                .HasForeignKey(b => b.AccountNumber);
            builder.Entity<BillPay>().HasOne<Payee>(b => b.Payee)
                .WithMany(p => p.Bills).HasForeignKey(b => b.PayeeID);
            builder.Entity<BillPay>().HasCheckConstraint("CH_BillPay_Amount", "Amount>0");

            builder.Entity<Login>().HasCheckConstraint("CH_Login_LoginID", "len(LoginID) = 8").
                HasCheckConstraint("CH_Login_PasswordHash", "len(PasswordHash) = 64");
            builder.Entity<Account>().HasCheckConstraint("CH_Account_Balance", "Balance >= 0");
            builder.Entity<Transaction>().
                HasOne(x => x.Account).WithMany(x => x.Transactions).HasForeignKey(x => x.AccountNumber);
            builder.Entity<Transaction>().HasCheckConstraint("CH_Transaction_Amount", "Amount > 0");

        }
    }
}
