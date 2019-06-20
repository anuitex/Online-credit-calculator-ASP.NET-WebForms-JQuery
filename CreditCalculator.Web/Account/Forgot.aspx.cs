using CreditCalculator.Configurations;
using CreditCalculator.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindByName(Email.Text);
            if (user == null || !manager.IsEmailConfirmed(user.Id))
            {
                FailureText.Text = "The user either does not exist or is not confirmed.";
                ErrorMessage.Visible = true;
                return;
            }
            loginForm.Visible = false;
            DisplayEmail.Visible = true;
        }
    }
}