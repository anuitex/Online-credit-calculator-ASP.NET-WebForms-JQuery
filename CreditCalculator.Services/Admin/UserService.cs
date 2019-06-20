using CreditCalculator.Configurations;
using CreditCalculator.Services.AutoMappers.Admin;
using CreditCalculator.ViewModels.Admin;
using DAL;
using DAL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;

namespace CreditCalculator.Services.Admin
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly BankPropositionRepository _bankPropositionRepository;
        private readonly CreditRequestRepository _creditRequestRepository;
        private readonly DepositRequestRepository _depositRequestRepository;

        private readonly UserMapper _userMapper;

        public UserService()
        {
            _userRepository = new UserRepository();
            _bankPropositionRepository = new BankPropositionRepository();
            _creditRequestRepository = new CreditRequestRepository();
            _depositRequestRepository = new DepositRequestRepository();

            _userMapper = new UserMapper();
        }


        public IdentityResult CreateUser(ApplicationUserManager manager, ApplicationSignInManager signInManager, AddUserViewModel viewModel)
        {
            var user = _userMapper.MapAddUserToModel(viewModel);

            IdentityResult result = manager.Create(user, viewModel.Password);

            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, viewModel.Role);
                signInManager.SignIn(user, false, false);
            }

            return result;
        }

        public List<AddUserViewModel> GetAllUsers()
        {
            var usersModel = _userRepository.GetAllUsers();

            var usersViewModel = _userMapper.MapGetAllUsersToViewModel(usersModel);

            return usersViewModel;
        }

        public void ChangeIsHasBankStatus(string adminId, bool status)
        {
            _userRepository.ChangeIsHasBankStatus(adminId, status);
        }

        public bool CheckIsHasBankStatus(string userId)
        {
            var result = _userRepository.CheckIsHasBankStatus(userId);

            return result;
        }


        public List<string> GetAllRoles(ApplicationDbContext context)
        {
            var allRoles = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)).Roles.ToList();
            var roleNames = new List<string>();

            foreach (var role in allRoles)
            {
                roleNames.Add(role.Name);
            }
            return roleNames;
        }

        public List<GetAllBankAdminsViewModel> GetAvailableBankAdmins()
        {
            var usersModel = _userRepository.GetAvailableBankAdmins();

            var usersViewModel = _userMapper.MapGetAllBankAdminsToViewModel(usersModel);

            return usersViewModel;
        }

        public void DeletePropositionsByUserId(string userId)
        {
            _bankPropositionRepository.DeletePropositionsByUserId(userId);
        }

        public void DeleteCreditsByUserId(string userId)
        {
            _creditRequestRepository.DeleteCreditsByUserId(userId);
        }

        public void DeleteDepositsByUserId(string userId)
        {
            _depositRequestRepository.DeleteDepositsByUserId(userId);
        }

        public void DeleteUserById(string userId)
        {
            _userRepository.DeleteUserById(userId);
        }

        public void UpdateUser(UpdateUserViewModel viewModel)
        {
            var model = _userMapper.MapUpdateUserToModel(viewModel);

            _userRepository.UpdateUser(model);
        }
    }
}
