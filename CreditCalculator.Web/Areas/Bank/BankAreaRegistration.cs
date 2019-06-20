using System.Web.Mvc;

namespace CreditCalculator.Web.Areas.Bank
{
    public class BankAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Bank";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Bank_default",
                "Bank/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}