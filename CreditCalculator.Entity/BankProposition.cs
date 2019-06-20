using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCalculator.Entity
{
    public class BankProposition
    {
        [Key]
        public string Id { get; set; }
        public string BankId { get; set; }

        [ForeignKey("BankId")]
        public Bank Bank { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string MinBetCredit { get; set; }
        public string MaxBetCredit { get; set; }
        public string MinBetDeposit { get; set; }
        public string MaxBetDeposit { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
