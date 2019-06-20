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
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser { UserName = Email.Text, Email = Email.Text };

            IdentityResult result = manager.Create(user, Password.Text);
            manager.AddToRole(user.Id, "User");

            if (result.Succeeded)
            {
                signInManager.SignIn(user, false, false);
                IdentityHelper.RedirectToReturnUrl("/Areas/User/Home", Response);
                return;
            }
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }
}