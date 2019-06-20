using CreditCalculator.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class AvailableBanksForUserRepository
    {
        private readonly ApplicationDbContext _context;

        public AvailableBanksForUserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<Bank> GetAllBanks()
        {
            var allBanksList = _context.Banks.ToList();

            return allBanksList;
        }

    }
}
