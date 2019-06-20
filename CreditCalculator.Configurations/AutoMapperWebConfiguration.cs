using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.Admin;
using CreditCalculator.ViewModels.Bank;

namespace CreditCalculator.Configurations
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<CreditRequestViewModel, CreditRequest>().ReverseMap();
            CreateMap<DepositRequestViewModel, DepositRequest>().ReverseMap();
            CreateMap<ViewModels.User.CreditRequestViewModel, CreditRequest>().ReverseMap();
            CreateMap<ViewModels.User.DepositRequestViewModel, DepositRequest>().ReverseMap();
            CreateMap<CreditDecisionRequestsViewModel, DepositRequest>().ReverseMap();
            CreateMap<ViewModels.Bank.BankViewModel, Bank>().ReverseMap();
            CreateMap<AddUserViewModel, ApplicationUser>().ReverseMap();
            CreateMap<AddBankViewModel, Bank>().ReverseMap();
            CreateMap<GetAllBankAdminsViewModel, ApplicationUser>().ReverseMap();
            CreateMap<ServiceViewModel, Service>().ReverseMap();
            CreateMap<BankPropositionViewModel, BankProposition>().ReverseMap();
            CreateMap<UpdateBankPropositionViewModel, BankProposition>().ReverseMap();
            CreateMap<AddBankPropositionViewModel, BankProposition>().ReverseMap();
            CreateMap<UpdateBankViewModel, Bank>().ReverseMap();
            CreateMap<UpdateUserViewModel, ApplicationUser>().ReverseMap();
        }

        public void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<OrganizationProfile>();
            });
        }
    }
}

