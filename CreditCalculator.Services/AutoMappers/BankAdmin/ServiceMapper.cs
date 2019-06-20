using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.Bank;
using System.Collections.Generic;

namespace CreditCalculator.Services.AutoMappers.BankAdmin
{
    public class ServiceMapper
    {
        public List<ServiceViewModel> MapGetAllServicesByBankIdToViewModel(List<Service> model)
        {
            var servisesViewModel = new List<ServiceViewModel>();

            if (model != null)
            {
                foreach (var request in model)
                {
                    ServiceViewModel viewModel = Mapper.Map<ServiceViewModel>(request);

                    servisesViewModel.Add(viewModel);
                }
            }
            return servisesViewModel;
        }
    }
}
