using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment9
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void toLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void toAddMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("createUser.aspx");
        }

        protected void toTheater_Click(object sender, EventArgs e)
        {
            Response.Redirect("Theater.aspx");
        }

        protected void DLLButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DLL.aspx");
        }
    }
}