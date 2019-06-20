using CreditCalculator.Entity.Enums;
using System;

namespace CreditCalculator.ViewModels.Bank
{
    public class CreditRequestViewModel
    {
        public string Id { get; set; }
        public string BankId { get; set; }
        public string UserId { get; set; }
        public string BankName { get; set; }

        public DateTime? CreationDate { get; set; }
        public string Curency { get; set; }
        public string GetMoney { get; set; }
        public string MonthQuantity { get; set; }
        public string BackMoney { get; set; }
        public string RateValue { get; set; }
        public RequestStatus? Status { get; set; }
        public bool? IsApproved { get; set; }
        public string Description { get; set; }
    }
}
