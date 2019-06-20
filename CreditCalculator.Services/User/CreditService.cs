using CreditCalculator.Services.AutoMappers.User;
using CreditCalculator.ViewModels.User;
using DAL.Repositories;

namespace CreditCalculator.Services.User
{
    public class CreditService
    {
        private readonly CreditRequestRepository _creditRequestRepository;
        private readonly CreditRequestMapper _creditMapper;

        public CreditService()
        {
            _creditRequestRepository = new CreditRequestRepository();
            _creditMapper = new CreditRequestMapper();
        }

        public void AddCreditRequest(CreditRequestViewModel viewModel)
        {
            var model = _creditMapper.MapAddCreditRequestToModel(viewModel);
            _creditRequestRepository.Create(model);
        }

    }
}
