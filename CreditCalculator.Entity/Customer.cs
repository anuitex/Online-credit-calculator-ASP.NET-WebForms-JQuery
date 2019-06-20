using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCalculator.Entity
{
    public class Customer
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }


        public DateTime? CreationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportId { get; set; }
        public string IdCode { get; set; }
        public string DateOfBirthday { get; set; }
    }
}
