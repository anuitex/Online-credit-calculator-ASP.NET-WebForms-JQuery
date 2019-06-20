using CreditCalculator.Entity.Enums;

namespace CreditCalculator.ViewModels.Bank
{
    public class DepositDecisionRequestsViewModel
    {
        public string Id { get; set; }
        public RequestStatus Status { get; set; }
        public string Description { get; set; }
    }
}
