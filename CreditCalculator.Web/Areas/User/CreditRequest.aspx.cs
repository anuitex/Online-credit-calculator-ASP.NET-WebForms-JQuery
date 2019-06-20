using CreditCalculator.Services.User;
using CreditCalculator.ViewModels.User;
using DAL.Identity;
using System;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Areas.User
{
    public partial class Credit : Page
    {
        private static CreditService _creditService;
        private readonly BankService _bankService;

        public Credit()
        {
            _creditService = new CreditService();
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
                this.bankId.Text = Request.QueryString["bankId"];

                var bank = _bankService.GetBankById(Request.QueryString["bankId"]);

                if (bank != null)
                {
                    this.bankName.Text = bank.Name;
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static string AddCreditRequest(CreditRequestViewModel model)
        {
            _creditService.AddCreditRequest(model);

            return "Ok!";
        }
    }
}