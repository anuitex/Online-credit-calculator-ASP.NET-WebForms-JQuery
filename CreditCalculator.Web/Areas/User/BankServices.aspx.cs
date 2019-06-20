using CreditCalculator.Services.User;
using DAL.Identity;
using System;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Areas.User
{
    public partial class BankServices : Page
    {
        private static BankService _bankService;

        public BankServices()
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

            if (!string.IsNullOrEmpty(Request.QueryString["bankId"]))
            {
                hiddenBankId.Text = Request.QueryString["bankId"];

                var bank = _bankService.GetBankById(Request.QueryString["bankId"]);

                if (bank != null)
                {
                    hiddenBankName.Text = bank.Name;
                }
            }
        }
    }
}
