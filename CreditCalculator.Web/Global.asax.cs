using CreditCalculator.Configurations;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace CreditCalculator.Web
{
    public class Global : HttpApplication
    {
        private readonly OrganizationProfile _organizationProfile = new OrganizationProfile();

        void Application_Start(object sender, EventArgs e)
        {
            _organizationProfile.InitializeMapper();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}