using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Member
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["SessionCounter"] = 0;

        }
        void Application_End(object sender, EventArgs e)
        {
            Response.Write("<hr /> The website was last visited on " + DateTime.Now.ToString());
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Exception objErr = Server.GetLastError().GetBaseException();
            Server.ClearError();
            string err = DateTime.Now.ToString() + "    Error in: " + Request.Url.ToString() +
                              "    Error Message: " + objErr.Message.ToString() + "\n";

            string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Errors.txt");
            File.AppendAllText(fileLocation, err);
            Response.Redirect("Default.aspx");
        }

        void Session_Start(object sender, EventArgs e)
        {
            // add 1 to counter whenever a new session starts
            int count = (int)Application["SessionCounter"];
            count++;
            Application["SessionCounter"] = count;
        }

        void Session_End(object sender, EventArgs e)
        {
            // subtract 1 to counter whenever a new session ends
            int count = (int)Application["SessionCounter"];
            count--;
            Application["SessionCounter"] = count;
        }
    }
}