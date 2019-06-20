using CreditCalculator.Services.AutoMappers.BankAdmin;
using CreditCalculator.ViewModels.Bank;
using DAL.Repositories;
using System.Collections.Generic;

namespace CreditCalculator.Services.BankAdmin
{
    public class ServicesService
    {
        private readonly BankPropositionRepository _bankPropositionRepository;
        private readonly BankPropositionMapper _bankPropositionMapper;

        public ServicesService()
        {
            _bankPropositionRepository = new BankPropositionRepository();
            _bankPropositionMapper = new BankPropositionMapper();
        }

        public List<BankPropositionViewModel> GetCreditPropositionsByAdminId(string userId)
        {
            var bankCreditPropositionsModel = _bankPropositionRepository.GetCreditPropositionsByAdminId(userId);
            var bankCreditPropositionsViewModel = _bankPropositionMapper.MapGetPropositionsByAdminIdToViewModel(bankCreditPropositionsModel);

            return bankCreditPropositionsViewModel;
        }

        public string GetBankIdByAdminId(string userId)
        {
            var bankId = _bankPropositionRepository.GetBankIdByAdminId(userId);

            return bankId;
        }

        public List<BankPropositionViewModel> GetDepositPropositionsByAdminId(string userId)
        {
            var bankDepositPropositionsModel = _bankPropositionRepository.GetDepositPropositionsByAdminId(userId);
            var bankDepositPropositionsViewModel = _bankPropositionMapper.MapGetPropositionsByAdminIdToViewModel(bankDepositPropositionsModel);

            return bankDepositPropositionsViewModel;
        }

        public void UpdateBankProposition(UpdateBankPropositionViewModel model)
        {
            var propositionModel = _bankPropositionMapper.MapUpdateBankPropositionToModel(model);

            _bankPropositionRepository.UpdateBankProposition(propositionModel);
        }

        public void AddBankProposition(AddBankPropositionViewModel model)
        {
            var propositionModel = _bankPropositionMapper.MapAddBankPropositionToModel(model);

            _bankPropositionRepository.AddBankProposition(propositionModel);
        }

        public void DeleteBankProposition(string propositionId)
        {
            _bankPropositionRepository.DeleteBankProposition(propositionId);
        }

    }
}
