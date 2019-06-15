﻿using SmartCities.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartCities
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.Configure();
        }
    }
}
