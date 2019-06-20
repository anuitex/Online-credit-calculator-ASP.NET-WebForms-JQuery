using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CreditCalculator.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreationDate { get; set; }
        public string BankId { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool IsHasBank { get; set; }
        public string Role { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            if (Gender != null)
            {
                userIdentity.AddClaim(new Claim(ClaimTypes.Gender, Gender));
            }
            if (string.IsNullOrEmpty(Age.ToString()))
            {
                userIdentity.AddClaim(new Claim("age", Age.ToString()));
            }
            return userIdentity;
        }
    }
}
