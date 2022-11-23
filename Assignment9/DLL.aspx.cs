using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dll;

namespace Member
{
    public partial class DLL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DLLButton_Click(object sender, EventArgs e)
        {
            Encrypt encrypt = new Encrypt();
            resultBox.Text = encrypt.encryptPassword(inputBox.Text);
        }
    }
}