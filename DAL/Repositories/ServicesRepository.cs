using CreditCalculator.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class ServicesRepository
    {
        private readonly ApplicationDbContext _context;

        public ServicesRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<Service> GetAllServicesByBankId(string bankId)
        {
            var services = _context.Services.Where(x => x.BankId == bankId).ToList();

            return services;
        }
    }
}
