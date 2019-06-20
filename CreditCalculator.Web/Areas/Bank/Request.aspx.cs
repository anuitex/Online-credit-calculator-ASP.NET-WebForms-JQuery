using CreditCalculator.Services.BankAdmin;
using CreditCalculator.ViewModels.Bank;
using DAL.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Areas.Bank
{
    public partial class Request : Page
    {
        private static RequestService _requestService;

        public Request()
        {
            _requestService = new RequestService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!authenticationManager.User.Identity.IsAuthenticated)
            {
                IdentityHelper.RedirectToReturnUrl("/Account/Login", Response);
            }

            var userId = Context.User.Identity.GetUserId();

            if (!string.IsNullOrEmpty(userId))
            {
                var model = _requestService.GetAllRequestsByBankAdminId(userId);

                creditRequestsSection.DataSource = model.CreditRequests;
                depositRequestsSection.DataSource = model.DepositRequests;

                creditRequestsSection.DataBind();
                depositRequestsSection.DataBind();
            }
        }

        [System.Web.Services.WebMethod]
        public static string CreditDecisionRequests(CreditDecisionRequestsViewModel model)
        {
            _requestService.CreditDecisionRequests(model);

            return "Ok";
        }

        [System.Web.Services.WebMethod]
        public static string DepositDecisionRequests(DepositDecisionRequestsViewModel model)
        {
            _requestService.DepositDecisionRequests(model);

            return "Ok";
        }
    }
}