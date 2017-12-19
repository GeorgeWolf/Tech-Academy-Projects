using System.Web.Mvc;

namespace AreaExample.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            // Note: I had to modify this a bit on the defaults
            // and add a namespace.

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "AreaExample.Areas.Admin.Controllers" }
            );
        }
    }
}