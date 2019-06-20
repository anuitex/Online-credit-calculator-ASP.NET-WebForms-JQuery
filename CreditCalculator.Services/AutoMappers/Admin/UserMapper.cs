using AutoMapper;
using CreditCalculator.Entity;
using CreditCalculator.ViewModels.Admin;
using System;
using System.Collections.Generic;

namespace CreditCalculator.Services.AutoMappers.Admin
{
    public class UserMapper
    {
        public List<AddUserViewModel> MapGetAllUsersToViewModel(List<ApplicationUser> model)
        {
            var usersViewModel = new List<AddUserViewModel>();

            if (model != null)
            {
                foreach (var user in model)
                {
                    AddUserViewModel viewModel = Mapper.Map<AddUserViewModel>(user);
                    usersViewModel.Add(viewModel);
                }
            }
            return usersViewModel;
        }

        public ApplicationUser MapAddUserToModel(AddUserViewModel viewModel)
        {
            var userModel = new ApplicationUser();

            if (viewModel != null)
            {
                userModel = Mapper.Map<ApplicationUser>(viewModel);
                userModel.Id = Guid.NewGuid().ToString();
                userModel.CreationDate = DateTime.UtcNow;
            }
            return userModel;
        }

        public List<GetAllBankAdminsViewModel> MapGetAllBankAdminsToViewModel(List<ApplicationUser> model)
        {
            var usersViewModel = new List<GetAllBankAdminsViewModel>();

            if (model != null)
            {
                foreach (var user in model)
                {
                    var userModel = Mapper.Map<GetAllBankAdminsViewModel>(user);
                    usersViewModel.Add(userModel);
                }
            }
            return usersViewModel;
        }


        public ApplicationUser MapUpdateUserToModel(UpdateUserViewModel viewModel)
        {
            var userModel = new ApplicationUser();

            if (viewModel != null)
            {
                userModel = Mapper.Map<ApplicationUser>(viewModel);
            }
            return userModel;
        }
    }
}
