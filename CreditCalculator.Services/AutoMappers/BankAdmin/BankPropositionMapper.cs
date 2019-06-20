using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.Bank;
using System;
using System.Collections.Generic;

namespace CreditCalculator.Services.AutoMappers.BankAdmin
{
    public class BankPropositionMapper
    {
        public List<BankPropositionViewModel> MapGetPropositionsByAdminIdToViewModel(List<BankProposition> model)
        {
            var bankPropositionsViewModel = new List<BankPropositionViewModel>();

            if (model.Count != 0)
            {
                foreach (var request in model)
                {
                    BankPropositionViewModel viewModel = Mapper.Map<BankPropositionViewModel>(request);
                    bankPropositionsViewModel.Add(viewModel);
                }
            }

            return bankPropositionsViewModel;
        }


        public List<BankPropositionViewModel> MapGetBankIdByAdminIdToViewModel(string bankId)
        {
            var bankPropositionsViewModel = new List<BankPropositionViewModel>();

            if (string.IsNullOrEmpty(bankId))
            {
                return bankPropositionsViewModel;
            }

            BankProposition newModel = new BankProposition();
            newModel.Id = string.Empty;
            newModel.BankId = bankId;
            newModel.Title = string.Empty;
            newModel.SubTitle = string.Empty;
            newModel.MinBetCredit = string.Empty;
            newModel.MaxBetCredit = string.Empty;
            newModel.MinBetDeposit = string.Empty;
            newModel.MaxBetDeposit = string.Empty;

            BankPropositionViewModel viewModel = Mapper.Map<BankPropositionViewModel>(newModel);

            bankPropositionsViewModel.Add(viewModel);

            return bankPropositionsViewModel;
        }

        public BankProposition MapUpdateBankPropositionToModel(UpdateBankPropositionViewModel viewModel)
        {
            var bankPropositionModel = new BankProposition();

            if (viewModel != null)
            {
                bankPropositionModel = Mapper.Map<BankProposition>(viewModel);
            }
            return bankPropositionModel;
        }

        public BankProposition MapAddBankPropositionToModel(AddBankPropositionViewModel viewModel)
        {
            var bankPropositionModel = new BankProposition();

            if (viewModel != null)
            {
                bankPropositionModel = Mapper.Map<BankProposition>(viewModel);
                bankPropositionModel.Id = Guid.NewGuid().ToString();
                bankPropositionModel.CreationDate = DateTime.UtcNow;
            }
            return bankPropositionModel;
        }

    }
}
