using CreditCalculator.Services.AutoMappers.User;
using CreditCalculator.ViewModels.User;
using DAL.Repositories;
using System.Collections.Generic;

namespace CreditCalculator.Services.User
{
    public class BankService
    {
        private readonly BankRepository _bankRepository;
        private readonly BankMapper _bankMapper;

        public BankService()
        {
            _bankRepository = new BankRepository();
            _bankMapper = new BankMapper();
        }

        public BankViewModel GetBankById(string bankId)
        {
            var bankModal = _bankRepository.GetBankById(bankId);

            var bankViewModal = _bankMapper.MapBankToViewModel(bankModal);

            return bankViewModal;
        }

        public List<BankViewModel> GetAllBanksBanks()
        {
            var bankModal = _bankRepository.GetAllBanks();

            var bankViewModal = _bankMapper.MapGetAllBanksToViewModel(bankModal);

            return bankViewModal;
        }
    }
}
