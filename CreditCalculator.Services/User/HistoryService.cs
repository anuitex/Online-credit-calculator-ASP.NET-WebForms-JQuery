using CreditCalculator.Services.AutoMappers.User;
using CreditCalculator.ViewModels.User;
using DAL.Repositories;

namespace CreditCalculator.Services.User
{
    public class HistoryService
    {
        private readonly CreditRequestRepository _creditRequestRepository;
        private readonly DepositRequestRepository _depositRequestRepository;
        private readonly CreditRequestMapper _creditRequestMapper;
        private readonly DepositRequestMapper _depositRequestMapper;

        public HistoryService()
        {
            _creditRequestRepository = new CreditRequestRepository();
            _depositRequestRepository = new DepositRequestRepository();
            _creditRequestMapper = new CreditRequestMapper();
            _depositRequestMapper = new DepositRequestMapper();
        }

        public GetAllRequestsViewModel GetAllRequestsByUserId(string userId)
        {
            var allRequestsViewModel = new GetAllRequestsViewModel();

            var creditsModel = _creditRequestRepository.GetCreditRequestsByUserId(userId);
            var depositsModel = _depositRequestRepository.GetDepositRequestsByUserId(userId);

            allRequestsViewModel.CreditRequests = _creditRequestMapper.MapGetAllRequestsByUserIdToViewModel(creditsModel);
            allRequestsViewModel.DepositRequests = _depositRequestMapper.MapGetAllRequestsByUserIdToViewModel(depositsModel);

            return allRequestsViewModel;
        }
    }
}
