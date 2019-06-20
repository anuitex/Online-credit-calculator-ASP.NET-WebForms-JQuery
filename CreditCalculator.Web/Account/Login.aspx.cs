using CreditCalculator.Entity;
using DAL;
using DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Account
{
    public partial class Login : Page
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public Login()
        {
            ApplicationDbContext = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            var signinManager = Context.GetOwinContext().GetUserManager<Configurations.ApplicationSignInManager>();

            var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

            if (result == SignInStatus.Success)
            {
                string userId = UserManager.FindByName(Email.Text)?.Id;
                var userRolesArray = UserManager.GetRoles(userId) as List<string>;

                if (userRolesArray[0] == "Admin")
                {
                    IdentityHelper.RedirectToReturnUrl("/Areas/Admin/Home", Response);
                }
                if (userRolesArray[0] == "BankAdmin")
                {
                    IdentityHelper.RedirectToReturnUrl("/Areas/Bank/Home", Response);
                }
                if (userRolesArray[0] == "User")
                {
                    IdentityHelper.RedirectToReturnUrl("/Areas/User/Home", Response);
                }
            }
            if (result == SignInStatus.LockedOut)
            {
                Response.Redirect("/Account/Lockout");

            }
            if (result == SignInStatus.RequiresVerification)
            {
                Response.Redirect($"/Account/TwoFactorAuthenticationSignIn?ReturnUrl={Request.QueryString["ReturnUrl"]}&RememberMe={RememberMe.Checked}", true);
            }
            if (result == SignInStatus.Failure)
            {
                FailureText.Text = "Invalid login attempt";
                ErrorMessage.Visible = true;

            }
        }
    }
}