using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using dll;
using Member.IV;

namespace Project5
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    { 
        //load the first default captcha string - tests - then it ingore user reload requests after
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ImageString.ImageUrl = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + "tests";
            }        
        }

        //refreshes the captcha image with a new string
        protected void refreshImage_Click(object sender, EventArgs e)
        {
            ImageString.ImageUrl = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + createString();        
        }

        //used to validate username - making sure that it is not already present in the xml file
        //used to add the new member to the member.xml file
        protected void Button1_Click(object sender, EventArgs e)
        {

            string captcha = ImageString.ImageUrl.Substring(Math.Max(0, ImageString.ImageUrl.Length - 5)); ;
            string compare = captchaBox.Text.Trim();
            Encrypt encrypt = new Encrypt();
            Member.XML.Service1Client xml = new Member.XML.Service1Client();
            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            //string strFullPath = System.IO.Path.GetFullPath(Server.MapPath("~/App_Data/Member.xml"));
            XDocument doc = XDocument.Load(fLocation);
            if (!xml.searchMember(UserName.Text, doc.Root))
            {
                if(captcha.Equals(compare))
                {
                    XElement result = xml.addMember(UserName.Text, encrypt.encryptPassword(Password.Text), doc.Root);
                    result.Save(fLocation);
                    Response.Redirect("UserLogin.aspx");
                }
            }
            else
            {
                result.Text = "Username already taken.";
            }
        }
        //used to create the new string when the captcha is reloaded
        private string createString()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string newString = string.Empty;
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                newString += chars[random.Next(chars.Length)];
            }
            return newString;
        }
    }
}