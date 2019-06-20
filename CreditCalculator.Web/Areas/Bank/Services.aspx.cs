using CreditCalculator.Entity.Enums;
using CreditCalculator.Services.BankAdmin;
using CreditCalculator.ViewModels.Bank;
using DAL.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CreditCalculator.Web.Areas.Bank
{
    public partial class Services : Page
    {
        private static ServicesService _servicesService;

        public Services()
        {
            _servicesService = new ServicesService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!authenticationManager.User.Identity.IsAuthenticated)
            {
                IdentityHelper.RedirectToReturnUrl("/Account/Login", Response);
            }
        }

        public void ChangeService(object sender, CommandEventArgs e)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();

            if (string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                return;
            }
            if (e.CommandArgument.ToString() == BankPropositionTitle.Credit.ToString())
            {
                var creditPropositions = _servicesService.GetCreditPropositionsByAdminId(userId);

                if (creditPropositions == null || creditPropositions.Count == 0)
                {
                    addServicePropositionHiddenBankId.Text = _servicesService.GetBankIdByAdminId(userId);
                }

                if (creditPropositions.Count > 0)
                {
                    addServicePropositionHiddenBankId.Text = creditPropositions.FirstOrDefault().BankId;
                }

                ServicesMenuWrapper.SetActiveView(CreditView);

                creditPropositionsSection.DataSource = creditPropositions;
                creditPropositionsSection.DataBind();
            }

            if (e.CommandArgument.ToString() == BankPropositionTitle.Deposit.ToString())
            {
                var depositPropositions = _servicesService.GetDepositPropositionsByAdminId(userId);

                if (depositPropositions == null || depositPropositions.Count == 0)
                {
                    addServicePropositionHiddenBankId.Text = _servicesService.GetBankIdByAdminId(userId);
                }

                if (depositPropositions.Count > 0)
                {
                    addServicePropositionHiddenBankId.Text = depositPropositions.FirstOrDefault().BankId;
                }

                ServicesMenuWrapper.SetActiveView(DepositView);

                depositPropositionsSection.DataSource = depositPropositions;
                depositPropositionsSection.DataBind();
            }
        }

        [WebMethod]
        public static string UpdateBankProposition(UpdateBankPropositionViewModel model)
        {
            _servicesService.UpdateBankProposition(model);

            return "Ok!";
        }

        [WebMethod]
        public static string AddBankProposition(AddBankPropositionViewModel model)
        {
            _servicesService.AddBankProposition(model);

            return "Ok!";
        }

        [WebMethod]
        public static string DeleteBankProposition(string propositionId)
        {
            _servicesService.DeleteBankProposition(propositionId);

            return "Ok!";
        }
    }
}