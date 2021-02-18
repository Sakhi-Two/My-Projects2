using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtEaseWeb
{
    public partial class Register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void pickUser(object sender, EventArgs e)
        {
            if (usertype.Value == "Student")
            {
                Response.Redirect("RegisterStudent.aspx");
            }
            else if (usertype.Value == "Merchant")
            {
                Response.Redirect("RegisterMerchant.aspx");
            }
        }
    }
}