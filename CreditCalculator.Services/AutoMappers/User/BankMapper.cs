using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.User;
using System.Collections.Generic;

namespace CreditCalculator.Services.AutoMappers.User
{
    public class BankMapper
    {
        public BankViewModel MapBankToViewModel(Bank model)
        {
            BankViewModel bankViewModel = Mapper.Map<BankViewModel>(model);

            return bankViewModel;
        }

        public List<BankViewModel> MapGetAllBanksToViewModel(List<Bank> model)
        {
            var viewModelList = new List<BankViewModel>();

            if (model != null)
            {
                foreach (var bank in model)
                {
                    viewModelList.Add(Mapper.Map<BankViewModel>(bank));
                }
            }

            return viewModelList;
        }
    }
}
