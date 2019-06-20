using System;

namespace CreditCalculator.ViewModels.Bank
{
    public class ServiceViewModel
    {
        public string Id { get; set; }
        public string BankId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }
    }
}
