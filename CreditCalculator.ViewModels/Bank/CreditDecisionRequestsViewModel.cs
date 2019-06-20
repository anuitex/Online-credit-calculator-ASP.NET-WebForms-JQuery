using CreditCalculator.Entity.Enums;

namespace CreditCalculator.ViewModels.Bank
{
   public class CreditDecisionRequestsViewModel
    {
        public string Id { get; set; }
        public RequestStatus Status { get; set; }
        public string Description { get; set; }
    }
}
