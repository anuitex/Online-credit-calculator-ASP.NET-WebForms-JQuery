using System.Web.Mvc;

namespace CreditCalculator.Web.Areas.User
{
    public class UserAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "User";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "User_default",
                "User/{controller}/{action}/{id}",
                new { action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}