using CreditCalculator.Services.User;
using CreditCalculator.ViewModels.User;
using DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Areas.User
{
    public partial class Bank : Page
    {
        private readonly BankService _bankService;

        public Bank()
        {
            _bankService = new BankService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!authenticationManager.User.Identity.IsAuthenticated)
            {
                IdentityHelper.RedirectToReturnUrl("/Account/Login", Response);
            }

            var bank = new List<BankViewModel>();

            if (!string.IsNullOrEmpty(Request.QueryString ["bankId"]))
            {
                var bankId = Request.QueryString ["bankId"];

                bank.Add(_bankService.GetBankById(bankId));

                if (bank != null)
                {
                    this.bankNameLabel.Text = bank.FirstOrDefault()?.Name;
                }
            }
        }
    }
}