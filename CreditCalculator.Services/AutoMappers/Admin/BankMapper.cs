using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.Admin;
using System;
using System.Collections.Generic;

namespace CreditCalculator.Services.AutoMappers.Admin
{
    public class BankMapper
    {
        public List<BankViewModel> MapGetAllBanksToViewModel(List<Bank> model)
        {
            var banksViewModel = new List<BankViewModel>();

            if (model != null)
            {
                foreach (var request in model)
                {
                    BankViewModel viewModel = Mapper.Map<BankViewModel>(request);

                    banksViewModel.Add(viewModel);
                }
            }
            return banksViewModel;
        }


        public Bank MapAddBankToModel(AddBankViewModel viewModel)
        {
            var bankModel = new Bank();

            if (viewModel != null)
            {
                bankModel = Mapper.Map<Bank>(viewModel);
                bankModel.Id = Guid.NewGuid().ToString();
                bankModel.CreationDate = DateTime.UtcNow;
            }
            return bankModel;
        }

        public Bank MapUpdateBankToModel(UpdateBankViewModel viewModel)
        {
            var bankModel = new Bank();

            if (viewModel != null)
            {
                bankModel = Mapper.Map<Bank>(viewModel);
            }
            return bankModel;
        }

    }
}
