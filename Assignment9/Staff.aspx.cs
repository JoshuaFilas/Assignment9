using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Staff
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            // number of active sessions
            LabelSessions.Text = Application["SessionCounter"].ToString();
            // get cookie
            HttpCookie cookie = Request.Cookies["StaffLogin" + Session.SessionID];
            // check if cookie is good
            if (cookie != null)
            {
                LabelGreeting.Text = "Welcome, " + cookie["Username"];
            }
        }
	}
}