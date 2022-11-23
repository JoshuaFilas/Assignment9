using dll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Member
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginFunc(object sender, EventArgs e)
        {
            Encrypt encrypt = new Encrypt();
            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            //string strFullPath = System.IO.Path.GetFullPath(Server.MapPath("~/App_Data/Member.xml"));
            XDocument xml = XDocument.Load(fLocation);
            if (authentication(UserName.Text, encrypt.encryptPassword(Password.Text), xml.Root))
            {
                Response.Redirect("Theater.aspx");
            }
            else
            {
                Output.Text = "Invalid login";
            }
        }
        private bool authentication(string username, string password, XElement xml)
        {
            XML.Service1Client service1Client = new XML.Service1Client();
            return service1Client.verification(username, password, xml);
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("createUser.aspx");
        }
    }
}