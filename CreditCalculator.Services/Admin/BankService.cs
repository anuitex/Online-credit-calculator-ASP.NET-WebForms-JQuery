using CreditCalculator.Entity;
using CreditCalculator.Services.AutoMappers.Admin;
using CreditCalculator.ViewModels.Admin;
using DAL.Repositories;
using System.Collections.Generic;

namespace CreditCalculator.Services.Admin
{
    public class BankService
    {
        private readonly BankRepository _bankRepository;
        private readonly BankPropositionRepository _bankPropositionRepository;
        private readonly CreditRequestRepository _creditRequestRepository;
        private readonly DepositRequestRepository _depositRequestRepository;
        private readonly UserRepository _userRepository;

        private readonly BankMapper _bankMapper;

        public BankService()
        {
            _bankRepository = new BankRepository();
            _bankPropositionRepository = new BankPropositionRepository();
            _creditRequestRepository = new CreditRequestRepository();
            _depositRequestRepository = new DepositRequestRepository();
            _userRepository = new UserRepository();

            _bankMapper = new BankMapper();
        }

        public List<BankViewModel> GetAllBanks()
        {
            var banksModel = _bankRepository.GetAllBanks();

            var banksViewModel = _bankMapper.MapGetAllBanksToViewModel(banksModel);

            return banksViewModel;
        }

        public Bank GetBankById(string bankId)
        {
            var bank = _bankRepository.GetBankById(bankId);

            return bank;
        }

        public void AddBank(AddBankViewModel bankViewModel)
        {
            var banksModel = _bankMapper.MapAddBankToModel(bankViewModel);

            _bankRepository.AddBank(banksModel);
        }

        public void UpdateBank(UpdateBankViewModel bankViewModel)
        {
            var bankModel = _bankMapper.MapUpdateBankToModel(bankViewModel);

            _bankRepository.UpdateBank(bankModel);
        }

        public void DeletePropositionsByBankId(string bankId)
        {
            _bankPropositionRepository.DeletePropositionsByBankId(bankId);
        }

        public void DeleteCreditsByBankId(string bankId)
        {
            _creditRequestRepository.DeleteCreditsByBankId(bankId);
        }

        public void DeleteDepositsByBankId(string bankId)
        {
            _depositRequestRepository.DeleteDepositsByBankId(bankId);
        }

        public void DeleteBank(string bankId)
        {
            _bankRepository.DeleteBank(bankId);
        }

        public void ChangeIsHasBankStatus(string bankId)
        {
            _userRepository.ChangeIsHasBankStatus(bankId, false);
        }
    }
}
