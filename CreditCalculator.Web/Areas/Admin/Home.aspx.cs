﻿using DAL.Identity;
using System;
using System.Web;
using System.Web.UI;

namespace CreditCalculator.Web.Areas.Admin
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!authenticationManager.User.Identity.IsAuthenticated)
            {
                IdentityHelper.RedirectToReturnUrl("/Account/Login", Response);
            }
        }
    }
}