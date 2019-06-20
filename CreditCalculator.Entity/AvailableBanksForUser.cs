using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCalculator.Entity
{
    public class AvailableBankForUser
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public string BankId { get; set; }

        [ForeignKey("BankId")]
        public Bank Bank { get; set; }

        public string Name { get; set; }
    }
}
