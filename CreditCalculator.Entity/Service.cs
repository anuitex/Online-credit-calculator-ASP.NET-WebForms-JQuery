using System;
using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Entity
{
    public class Service
    {
        [Key]
        public string Id { get; set; }
        public string BankId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }
    }
}
