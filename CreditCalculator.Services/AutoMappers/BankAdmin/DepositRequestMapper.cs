using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.Bank;
using System;
using System.Collections.Generic;

namespace CreditCalculator.Services.AutoMappers.BankAdmin
{
    public class DepositRequestMapper
    {
        public List<DepositRequestViewModel> MapGetAllRequestsByUserIdToViewModel(List<DepositRequest> model)
        {
            var requestViewModel = new List<DepositRequestViewModel>();

            if (model != null)
            {
                foreach (var request in model)
                {
                    DepositRequestViewModel viewModel = Mapper.Map<DepositRequestViewModel>(request);

                    requestViewModel.Add(viewModel);
                }
            }
            return requestViewModel;
        }

        public DepositRequest MapAddDepositRequestToModel(DepositRequestViewModel model)
        {
            DepositRequest bankDeposit = Mapper.Map<DepositRequest>(model);
            bankDeposit.Id = Guid.NewGuid().ToString();
            bankDeposit.CreationDate = DateTime.UtcNow;

            return bankDeposit;
        }

        public DepositRequest MapDepositDecisionRequests(DepositDecisionRequestsViewModel viewModel, DepositRequest currentRequest)
        {
            currentRequest.Status = viewModel.Status;
            currentRequest.Description = viewModel.Description;

            return currentRequest;
        }


        public List<DepositRequestViewModel> MapGetDepositRequestsByBankIdToViewModel(List<DepositRequest> model)
        {
            var requestViewModel = new List<DepositRequestViewModel>();

            if (model != null)
            {
                foreach (var request in model)
                {
                    DepositRequestViewModel viewModel = Mapper.Map<DepositRequestViewModel>(request);

                    requestViewModel.Add(viewModel);
                }
            }
            return requestViewModel;
        }
    }
}
