using CreditCalculator.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class DepositRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public DepositRequestRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Create(DepositRequest deposit)
        {
            _context.DepositRequests.Add(deposit);
            _context.SaveChanges();
        }

        public List<DepositRequest> GetDepositRequestsByUserId(string userId)
        {
            var requests = _context.DepositRequests.Where(x => x.UserId == userId).ToList();

            return requests;
        }

        public List<DepositRequest> GetAllDepositRequests()
        {
            var requests = _context.DepositRequests.ToList();

            return requests;
        }

        public DepositRequest GetDepositRequestById(string requestId)
        {
            var request = _context.DepositRequests.FirstOrDefault(x => x.Id == requestId);

            return request;
        }

        public void UpdateRequest(DepositRequest depositRequest)
        {
            var request = _context.DepositRequests.FirstOrDefault(x => x.Id == depositRequest.Id);

            if (request != null)
            {
                _context.SaveChanges();
            }
        }

        public List<DepositRequest> GetDepositRequestsByBankId(string bankId)
        {
            var requests = _context.DepositRequests.Where(x => x.BankId == bankId).ToList();

            return requests;
        }

        public List<DepositRequest> GetDepositRequestsByBankAdminId(string bankAdminId)
        {
            var requests = _context.DepositRequests.Where(x => x.Bank.AdminId == bankAdminId).ToList();

            return requests;
        }

        public void DeleteDepositsByBankId(string bankId)
        {
            var requests = _context.DepositRequests.Where(x => x.BankId == bankId).ToList();

            if (requests.Count != 0)
            {
                _context.DepositRequests.RemoveRange(requests);
                _context.SaveChanges();
            }
        }


        public void DeleteDepositsByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            var credits = _context.DepositRequests.Where(x => x.Bank.Id == x.Bank.AdminId && x.Bank.AdminId == userId).ToList();

            if (credits.Count != 0)
            {
                _context.DepositRequests.RemoveRange(credits);
                _context.SaveChanges();
            }
        }

    }
}
