using dll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Member
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {

            if (authentication(UserName.Text, Password.Text))
            {
                // get username/password
                string cookieId = "StaffLogin" + Session.SessionID;
                // create cookie for session
                HttpCookie cookie = new HttpCookie(cookieId);
                // store username/password in cookie
                cookie["Username"] = UserName.Text;
                cookie["Password"] = Password.Text;
                cookie.Expires = DateTime.Now.AddDays(1);
                // add cookie to response
                Response.Cookies.Add(cookie);
                // redirect to staff page
                Response.Redirect("Staff.aspx");
            }
            else
            {
                Output.Text = "Invalid login";
            }
        }

        private bool authentication(string username, string password)
        {
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Staff.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(fLocation);

            XmlNode usernameNode = doc.SelectSingleNode("/users/user[username='" + username + "']/username");
            XmlNode passwordNode = doc.SelectSingleNode("/users/user[username='" + username + "']/password");

            if (usernameNode == null && passwordNode == null)
            {
                return false;
            }

            if (username.Equals(usernameNode.InnerText) && password.Equals(passwordNode.InnerText))
            {
                return true;
            }

            return false;
        }

    }
}