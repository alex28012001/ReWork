﻿using Microsoft.AspNet.SignalR;
using ReWork.WebSite.App_Start;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ReWork.WebSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IocConfig.ConfigureContainer();

            log4net.Config.XmlConfigurator.Configure();
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(6);
        }
    }
}
