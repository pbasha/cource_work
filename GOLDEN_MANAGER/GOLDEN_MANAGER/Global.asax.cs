
using GOLDEN_MANAGER.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace GOLDEN_MANAGER
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ManagerDBContext>(null);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
