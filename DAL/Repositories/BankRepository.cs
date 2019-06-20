using CreditCalculator.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class BankRepository
    {
        private readonly ApplicationDbContext _context;

        public BankRepository()
        {
            _context = new ApplicationDbContext();
        }
        
        public bool CheckExistsBankByBankAdminEmail(string email)
        {
            return _context.Banks.Any(x => x.Email == email);
        }

        public List<Bank> GetAllBanks()
        {
            var banks = _context.Banks.ToList();

            return banks;
        }

        public Bank GetBankById(string bankId)
        {
            var bank = _context.Banks.FirstOrDefault(x => x.Id == bankId);
            return bank;
        }

        public void AddBank(Bank bank)
        {
            _context.Banks.Add(bank);
            _context.SaveChanges();
        }

        public void UpdateBank(Bank newBank)
        {
            var bank = _context.Banks.FirstOrDefault(x => x.Id == newBank.Id);

            if (bank == null)
            {
                return;
            }

            bank.Name = newBank.Name;
            bank.Information = newBank.Information;
            bank.PhoneNumber = newBank.PhoneNumber;
            bank.Country = newBank.Country;
            bank.Address = newBank.Address;

            _context.SaveChanges();
        }

        public void DeleteBank(string bankId)
        {
            var bank = _context.Banks.FirstOrDefault(x => x.Id == bankId);

            if (bank != null)
            {
                _context.Banks.Remove(bank);
                _context.SaveChanges();
            }
        }
    }
}
