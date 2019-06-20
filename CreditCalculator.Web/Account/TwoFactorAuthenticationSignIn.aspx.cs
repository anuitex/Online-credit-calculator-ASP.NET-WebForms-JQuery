using CreditCalculator.Configurations;
using CreditCalculator.Entity;
using DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Account
{
    public partial class TwoFactorAuthenticationSignIn : Page
    {
        private readonly ApplicationSignInManager _signinManager;
        private readonly ApplicationUserManager _manager;

        public TwoFactorAuthenticationSignIn()
        {
            _manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            _signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
        }

        protected sealed override HttpContext Context => base.Context;

        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = _signinManager.GetVerifiedUserId<ApplicationUser, string>();
            if (userId == null)
            {
                Response.Redirect("/Account/Error", true);
            }
            var userFactors = _manager.GetValidTwoFactorProviders(userId);
            Providers.DataSource = userFactors.Select(x => x).ToList();
            Providers.DataBind();
        }

        protected void CodeSubmit_Click(object sender, EventArgs e)
        {
            bool.TryParse(Request.QueryString["RememberMe"], out var rememberMe);

            var result = _signinManager.TwoFactorSignIn(SelectedProvider.Value, Code.Text, rememberMe, RememberBrowser.Checked);
            switch (result)
            {
                case SignInStatus.Success:
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    break;
                case SignInStatus.LockedOut:
                    Response.Redirect("/Account/Lockout");
                    break;
                default:
                    FailureText.Text = "Invalid code";
                    ErrorMessage.Visible = true;
                    break;
            }
        }

        protected void ProviderSubmit_Click(object sender, EventArgs e)
        {
            if (!_signinManager.SendTwoFactorCode(Providers.SelectedValue))
            {
                Response.Redirect("/Account/Error");
            }

            var user = _manager.FindById(_signinManager.GetVerifiedUserId());
            if (user != null)
            {
                var code = _manager.GenerateTwoFactorToken(user.Id, Providers.SelectedValue);
            }

            SelectedProvider.Value = Providers.SelectedValue;
            sendcode.Visible = false;
            verifycode.Visible = true;
        }
    }
}