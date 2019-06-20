using CreditCalculator.Services.User;
using CreditCalculator.ViewModels.User;
using DAL.Identity;
using System;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Areas.User
{
    public partial class Deposit : Page
    {
        private static DepositService _depositService;
        private readonly BankService _bankService;

        public Deposit()
        {
            _depositService = new DepositService();
            _bankService = new BankService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!authenticationManager.User.Identity.IsAuthenticated)
            {
                IdentityHelper.RedirectToReturnUrl("/Account/Login", Response);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["bankId"]))
            {
                bankId.Text = Request.QueryString["bankId"];
                var bank = _bankService.GetBankById(Request.QueryString["bankId"]);

                if (bank != null)
                {
                    bankName.Text = bank.Name;
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static string AddDepositRequest(DepositRequestViewModel model)
        {
            _depositService.AddDepositRequest(model);

            return "Ok!";
        }
    }
}