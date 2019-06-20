using CreditCalculator.Entity;
using System.Collections.Generic;
using System.Linq;
using CreditCalculator.Entity.Enums;

namespace DAL.Repositories
{
    public class BankPropositionRepository
    {
        private readonly ApplicationDbContext _context;

        public BankPropositionRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<BankProposition> GetAllPropositionsByBankId(string bankId)
        {
            var propositions = _context.BankPropositions.Where(x => x.BankId == bankId).ToList();
            return propositions;
        }

        public List<BankProposition> GetCreditPropositionsByAdminId(string adminId)
        {
            var propositions = _context.BankPropositions.Where(x => x.Bank.AdminId == adminId && x.Title == BankPropositionTitle.Credit.ToString()).ToList();
            return propositions;
        }

        public string GetBankIdByAdminId(string adminId)
        {
            var bank = _context.Banks.FirstOrDefault(x => x.AdminId == adminId);

            return bank != null ? bank.Id : string.Empty;
        }

        public List<BankProposition> GetDepositPropositionsByAdminId(string adminId)
        {
            var propositions = _context.BankPropositions.Where(x => x.Bank.AdminId == adminId && x.Title == BankPropositionTitle.Deposit.ToString()).ToList();
            return propositions;
        }

        public void UpdateBankProposition(BankProposition proposition)
        {
            var propositionResult = _context.BankPropositions.FirstOrDefault(x => x.Id == proposition.Id);

            if (propositionResult == null)
            {
                return;
            }

            propositionResult.Title = proposition.Title;
            propositionResult.BankId = proposition.BankId;
            propositionResult.SubTitle = proposition.SubTitle;
            propositionResult.MinBetCredit = proposition.MinBetCredit;
            propositionResult.MaxBetCredit = proposition.MaxBetCredit;
            propositionResult.MinBetDeposit = proposition.MinBetDeposit;
            propositionResult.MaxBetDeposit = proposition.MaxBetDeposit;

            _context.SaveChanges();
        }

        public void AddBankProposition(BankProposition proposition)
        {
            if (proposition != null)
            {
                _context.BankPropositions.Add(proposition);
                _context.SaveChanges();
            }
        }

        public void DeleteBankProposition(string propositionId)
        {
            if (string.IsNullOrEmpty(propositionId))
            {
                return;
            }

            var proposition = _context.BankPropositions.FirstOrDefault(x => x.Id == propositionId);

            if (proposition != null)
            {
                _context.BankPropositions.Remove(proposition);
                _context.SaveChanges();
            }
        }

        public void DeletePropositionsByBankId(string bankId)
        {
            if (string.IsNullOrEmpty(bankId))
            {
                return;
            }
            var propositions = _context.BankPropositions.Where(x => x.BankId == bankId).ToList();

            if (propositions.Count != 0)
            {
                _context.BankPropositions.RemoveRange(propositions);
                _context.SaveChanges();
            }
        }

        public void DeletePropositionsByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }
            var propositions = _context.BankPropositions.Where(x => x.Bank.Id == x.Bank.AdminId && x.Bank.AdminId == userId).ToList();

            if (propositions.Count != 0)
            {
                _context.BankPropositions.RemoveRange(propositions);
                _context.SaveChanges();
            }
        }
    }
}
