using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class Checkout : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string stuNum = Request.QueryString["stuNum"];
            QuotationClass[] quote = client.getQuoteInfo(stuNum);
            int merchantID;
            MerchantClass mer;
            string show = "";
            foreach (QuotationClass q in quote)
            {
                merchantID = q.merchID ?? default(int);
                mer = client.GetMerchant(merchantID);

                show += "<tr>";
                show += "<td>";
                show += "<img src=" + mer.image + " height='40' width='40' alt=''>";
                show += "</td>";
                show += "<td>";
                show += "<h5>" + mer.name + "</h5>";
                show += "</td>";
                show += "<td>";
                show += "<h5>" + mer.contact + "</h5>";
                show += "</td>";
                show += "<td>";
                show += "<h5>" + mer.email + "</h5>";
                show += "</td>";
                show += "</tr>";
            }
            chats.InnerHtml = show;
        }

        protected void GoToChat_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Chat/SignalRChat/chatRoom.html");
        }
    }
}