using System.Data.Entity;
using CreditCalculator.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<CreditRequest> CreditRequests { get; set; }
        public virtual DbSet<DepositRequest> DepositRequests { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<BankProposition> BankPropositions { get; set; }

        public ApplicationDbContext() : base("CreditCalculatorDb", false)
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
