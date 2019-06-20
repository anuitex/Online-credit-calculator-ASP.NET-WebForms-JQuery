using System.Collections.Generic;

namespace CreditCalculator.ViewModels.Bank
{
    public class GetAllRequestsViewModel
    {
        public List<CreditRequestViewModel> CreditRequests { get; set; }
        public List<DepositRequestViewModel> DepositRequests { get; set; }

        public GetAllRequestsViewModel()
        {
            CreditRequests = new List<CreditRequestViewModel>();
            DepositRequests = new List<DepositRequestViewModel>();
        }
    }
}
