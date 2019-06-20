using CreditCalculator.Services.User;
using DAL.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Areas.User
{
    public partial class Home : Page
    {
        private readonly HomeService _homeService;

        public Home()
        {
            _homeService = new HomeService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!authenticationManager.User.Identity.IsAuthenticated)
            {
                IdentityHelper.RedirectToReturnUrl("/Account/Login", Response);
            }

            var userId = Context.User.Identity.GetUserId();
            var model = _homeService.GetAllRequestsByUserId(userId);

            allCreditRequestsSection.DataSource = model.CreditRequests;
            allDepositRequestsSection.DataSource = model.DepositRequests;

            allCreditRequestsSection.DataBind();
            allDepositRequestsSection.DataBind();
        }
    }
}