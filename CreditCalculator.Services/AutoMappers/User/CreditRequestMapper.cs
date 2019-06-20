using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.User;
using System;
using System.Collections.Generic;

namespace CreditCalculator.Services.AutoMappers.User
{
    public class CreditRequestMapper
    {
        public List<CreditRequestViewModel> MapGetAllRequestsByUserIdToViewModel(List<CreditRequest> model)
        {
            var requestViewModel = new List<CreditRequestViewModel>();

            if (model != null)
            {
                foreach (var request in model)
                {
                    CreditRequestViewModel viewModel = Mapper.Map<CreditRequestViewModel>(request);

                    requestViewModel.Add(viewModel);
                }
            }
            return requestViewModel;
        }

        public CreditRequest MapAddCreditRequestToModel(CreditRequestViewModel model)
        {
            CreditRequest bankCredit = Mapper.Map<CreditRequest>(model);
            bankCredit.Id = Guid.NewGuid().ToString();
            bankCredit.CreationDate = DateTime.UtcNow;

            return bankCredit;
        }

    }
}
