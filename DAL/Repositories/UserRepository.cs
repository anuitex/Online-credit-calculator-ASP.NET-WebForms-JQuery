using CreditCalculator.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<ApplicationUser> GetAllUsers()
        {
            var users = _context.Users.ToList();

            return users;
        }

        public string GetBankIdByAdminId(string adminId)
        {
            var bankId = _context.Users.FirstOrDefault(x => x.Id == adminId)?.BankId;

            return bankId;
        }

        public List<ApplicationUser> GetAvailableBankAdmins()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var role = roleManager.FindByName("BankAdmin").Users.First();
            var usersInRole = _context.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId) && u.IsHasBank == false).ToList();

            return usersInRole;
        }

        public ApplicationUser GetUserById(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            return user;
        }

        public void ChangeIsHasBankStatus(string adminId, bool status)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == adminId);

            if (user != null)
            {
                user.IsHasBank = status;
                _context.SaveChanges();
            }
        }

        public bool CheckIsHasBankStatus(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            bool result = false;

            if (user != null)
            {
                result = user.IsHasBank;
            }

            return result;
        }

        public void DeleteUserById(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                _context.Users.Remove(user);

                _context.SaveChanges();
            }
        }

        public void UpdateUser(ApplicationUser model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == model.Id);

            if (user == null)
            {
                return;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PassportSeries = model.PassportSeries;
            user.PassportNumber = model.PassportNumber;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;

            _context.SaveChanges();
        }
    }
}
