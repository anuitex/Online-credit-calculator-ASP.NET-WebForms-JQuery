using CreditCalculator.Services.AutoMappers.BankAdmin;
using CreditCalculator.ViewModels.Bank;
using DAL.Repositories;

namespace CreditCalculator.Services.BankAdmin
{
    public class RequestService
    {
        private readonly CreditRequestRepository _creditRequestRepository;
        private readonly DepositRequestRepository _depositRequestRepository;
        private readonly CreditRequestMapper _creditRequestMapper;
        private readonly DepositRequestMapper _depositRequestMapper;

        public RequestService()
        {
            _creditRequestRepository = new CreditRequestRepository();
            _depositRequestRepository = new DepositRequestRepository();
            _creditRequestMapper = new CreditRequestMapper();
            _depositRequestMapper = new DepositRequestMapper();
        }

        public GetAllRequestsViewModel GetAllRequestsByBankAdminId(string bankAdminId)
        {
            var allRequestsViewModel = new GetAllRequestsViewModel();

            var creditRequestsModel = _creditRequestRepository.GetCreditRequestsByBankAdminId(bankAdminId);
            var depositRequestsModel = _depositRequestRepository.GetDepositRequestsByBankAdminId(bankAdminId);

            allRequestsViewModel.CreditRequests = _creditRequestMapper.MapGetCreditRequestsByBankIdToViewModel(creditRequestsModel);
            allRequestsViewModel.DepositRequests = _depositRequestMapper.MapGetDepositRequestsByBankIdToViewModel(depositRequestsModel);

            return allRequestsViewModel;
        }

        public void CreditDecisionRequests(CreditDecisionRequestsViewModel viewModel)
        {
            var currentRequest = _creditRequestRepository.GetCreditRequestById(viewModel.Id);
            var model = _creditRequestMapper.MapCreditDecisionRequests(viewModel, currentRequest);
            _creditRequestRepository.UpdateRequest(model);
        }

        public void DepositDecisionRequests(DepositDecisionRequestsViewModel viewModel)
        {
            var currentRequest = _depositRequestRepository.GetDepositRequestById(viewModel.Id);
            var model = _depositRequestMapper.MapDepositDecisionRequests(viewModel, currentRequest);
            _depositRequestRepository.UpdateRequest(model);
        }
    }
}
