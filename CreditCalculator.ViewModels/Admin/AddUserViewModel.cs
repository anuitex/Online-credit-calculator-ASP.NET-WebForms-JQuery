using System;

namespace CreditCalculator.ViewModels.Admin
{
    public class AddUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Password { get; set; }
    }
}
