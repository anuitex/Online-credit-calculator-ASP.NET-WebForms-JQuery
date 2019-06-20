using CreditCalculator.Services.AutoMappers.User;
using CreditCalculator.ViewModels.User;
using DAL.Repositories;

namespace CreditCalculator.Services.User
{
    public class DepositService
    {
        private readonly DepositRequestRepository _depositRequestRepository;
        private readonly DepositRequestMapper _depositMapper;

        public DepositService()
        {
            _depositRequestRepository = new DepositRequestRepository();
            _depositMapper = new DepositRequestMapper();
        }

        public void AddDepositRequest(DepositRequestViewModel viewModel)
        {
            var model = _depositMapper.MapAddDepositRequestToModel(viewModel);
            _depositRequestRepository.Create(model);
        }
    }
}
