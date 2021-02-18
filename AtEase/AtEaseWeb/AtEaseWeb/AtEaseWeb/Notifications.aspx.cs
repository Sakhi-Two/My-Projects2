using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class Notifications : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string show = "";
            int mID = client.GetMerchID(Session["email"].ToString());
            MerchantClass m = client.GetMerchant(mID);
            if(m.strikes<=1)
            {
                show += "<h1 style='background-color:green;'>Someone has complained about your service. You have one strike.</h1>";
            }
            else if(m.strikes==2)
            {
                show += "<h1 style='background-color:orange;'>More than one person has complained about your service. You have two strikes.</h1>";
            }
            else
            {
                show += "<h1 style='background-color:red;'>Multiple people have complained about your service. Your account is about to be disabled.</h1>";
            }
            info.InnerHtml = show;
        }
    }
}