﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AtEaseWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Redirect mobile users to the mobile home page
            HttpRequest httpRequest = HttpContext.Current.Request;
            if (httpRequest.Browser.IsMobileDevice)
            {
                string path = httpRequest.Url.PathAndQuery;

               bool isOnMobilePage = path.StartsWith("/Mobile/",
                                       StringComparison.OrdinalIgnoreCase);
                if (!isOnMobilePage)
                {
                    string redirectTo = "~/Mobile/LoginMobile.aspx";

                    // Could also add special logic to redirect from certain 
                    // recognized pages to the mobile equivalents of those 
                    // pages (where they exist). For example,
                    // if (HttpContext.Current.Handler is UserRegistration)
                    //     redirectTo = "~/Mobile/Register.aspx";

                    HttpContext.Current.Response.Redirect(redirectTo);
                }
            }
        }
    }
}