using CreditCalculator.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class CreditRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditRequestRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Create(CreditRequest credit)
        {
            _context.CreditRequests.Add(credit);
            _context.SaveChanges();
        }

        public List<CreditRequest> GetCreditRequestsByUserId(string userId)
        {
            var requests = _context.CreditRequests.Where(x => x.UserId == userId).ToList();

            return requests;
        }

        public List<CreditRequest> GetAllCreditRequests()
        {
            var requests = _context.CreditRequests.ToList();

            return requests;
        }

        public CreditRequest GetCreditRequestById(string requestId)
        {
            var requests = _context.CreditRequests.FirstOrDefault(x => x.Id == requestId);

            return requests;
        }

        public void UpdateRequest(CreditRequest currentRequest)
        {
            var request = _context.CreditRequests.FirstOrDefault(x => x.Id == currentRequest.Id);

            if (request != null)
            {
                _context.SaveChanges();
            }
        }

        public List<CreditRequest> GetCreditRequestsByBankAdminId(string bankAdminId)
        {
            var requests = _context.CreditRequests.Where(x => x.Bank.AdminId == bankAdminId).ToList();

            return requests;
        }

        public void DeleteCreditsByBankId(string bankId)
        {
            var requests = _context.CreditRequests.Where(x => x.BankId == bankId).ToList();

            if (requests.Count != 0)
            {
                _context.CreditRequests.RemoveRange(requests);
                _context.SaveChanges();
            }
        }


        public void DeleteCreditsByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            var credits = _context.CreditRequests.Where(x => x.Bank.Id == x.Bank.AdminId && x.Bank.AdminId == userId).ToList();

            if (credits.Count != 0)
            {
                _context.CreditRequests.RemoveRange(credits);
                _context.SaveChanges();
            }
        }
    }
}
