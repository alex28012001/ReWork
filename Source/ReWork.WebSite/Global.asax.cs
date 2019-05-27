﻿using Microsoft.AspNet.SignalR;
using ReWork.Logic.Hubs.Implementation;
using ReWork.WebSite.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            //AppDomain.CurrentDomain.Load(typeof(NotificationHub).Assembly.FullName);
            //AppDomain.CurrentDomain.Load(typeof(ChatHub).Assembly.FullName);

            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(6);
        }
    }
}
