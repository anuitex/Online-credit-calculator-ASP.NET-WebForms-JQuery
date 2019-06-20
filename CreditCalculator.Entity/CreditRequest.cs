using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CreditCalculator.Entity.Enums;

namespace CreditCalculator.Entity
{
    public class CreditRequest
    {
        [Key]
        public string Id { get; set; }

        public string BankId { get; set; }

        [ForeignKey("BankId")]
        public virtual Bank Bank { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public string BankName { get; set; }

        public DateTime? CreationDate { get; set; }
        public string Curency { get; set; }

        public string GetMoney { get; set; }
        public string MonthQuantity { get; set; }
        public string BackMoney { get; set; }
        public string RateValue { get; set; }

        public RequestStatus Status { get; set; }
        public bool? IsApproved { get; set; }
        public string Description { get; set; }
    }
}
