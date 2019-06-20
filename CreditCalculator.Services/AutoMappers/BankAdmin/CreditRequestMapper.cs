using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.Bank;
using System;
using System.Collections.Generic;

namespace CreditCalculator.Services.AutoMappers.BankAdmin
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
            CreditRequest request = Mapper.Map<CreditRequest>(model);
            request.Id = Guid.NewGuid().ToString();
            request.CreationDate = DateTime.UtcNow;

            return request;
        }
        
        public CreditRequest MapCreditDecisionRequests(CreditDecisionRequestsViewModel viewModel, CreditRequest currentRequest)
        {
            currentRequest.Status = viewModel.Status;
            currentRequest.Description = viewModel.Description;

            return currentRequest;
        }

        public List<CreditRequestViewModel> MapGetCreditRequestsByBankIdToViewModel(List<CreditRequest> model)
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
    }
}
