using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.User;
using System;
using System.Collections.Generic;

namespace CreditCalculator.Services.AutoMappers.User
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

    }
}
