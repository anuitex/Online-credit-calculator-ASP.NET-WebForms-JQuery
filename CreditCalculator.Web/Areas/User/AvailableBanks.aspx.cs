using CreditCalculator.Services.User;
using System;
using System.Web.UI;

namespace CreditCalculator.Web.Areas.User
{
    public partial class AvailableBanks : Page
    {
        private readonly BankService _bankService;

        public AvailableBanks()
        {
            _bankService = new BankService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var allBanksList = _bankService.GetAllBanksBanks();

            availableBanksList.DataSource = allBanksList;
            availableBanksList.DataBind();
        }
    }
}