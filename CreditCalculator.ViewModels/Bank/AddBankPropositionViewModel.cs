using System;

namespace CreditCalculator.ViewModels.Bank
{
    public class AddBankPropositionViewModel
    {
        public string BankId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string MinBetCredit { get; set; }
        public string MaxBetCredit { get; set; }
        public string MinBetDeposit { get; set; }
        public string MaxBetDeposit { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
