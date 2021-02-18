using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;
using Microsoft.Ajax.Utilities;

namespace AtEaseWeb
{
    public partial class Feedback : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        static int rating;
        static string review;
        static int merchantID = 0;
        static int counter;
        protected void Page_Load(object sender, EventArgs e)
        {

            counter = Convert.ToInt32(Request.QueryString["counter"]);
            counter++;

            string stuNum = client.getStuNumber(Session["email"].ToString());
            FeedbackClass[] feeds = client.getAllFeedback(stuNum);
            string show = "";
            MerchantClass mer;
            int checkRated;
            int lngt = feeds.Length;

            foreach (FeedbackClass f in feeds)
            {
                if (counter == Array.IndexOf(feeds, f))
                {
                    mer = client.GetMerchant(f.merchID);
                    merchantID = f.merchID;
                    checkRated = client.GetIsRated(merchantID, stuNum);
                    if (checkRated == 0)
                    {
                        show += "<tr>";
                        show += "<td><img src=" + mer.image + " height='50px' width='50px'></td>";
                        show += "<td>" + mer.name + "</td>";
                        show += "<td>";
                        show += "<select name='rates' id='rates'>";
                        show += "<option value = '1' > 1 </option>";
                        show += "<option value = '2' > 2 </option>";
                        show += "<option value = '3' > 3 </option>";
                        show += "<option value = '4' > 4 </option>";
                        show += "<option value = '5' > 5 </option>";
                        show += "</select>";
                        show += "</td>";
                        show += "<td><input class='css-input' type='text' name='newRev' placeholder='Enter your review' id='newRev' runat='server'></td>";
                        show += "<td class='shoping__cart__item__close'>";
                        show += "<a href='Feedback.aspx?repMer=" + mer.merchID + "'><span class='glyphicon glyphicon-exclamation-sign'></span></a>";
                        show += "</td>";
                        show += "</tr>";
                    }
                    else if (checkRated == 1)
                    {
                        Response.Redirect("Feedback.aspx?counter=" + counter);
                    }
                    else
                    {
                        Response.Redirect("Home.aspx");
                    }
                }
            }
            table.InnerHtml = show;

            if (Request.QueryString["repMer"] != null)
            {
                int merchantID = Convert.ToInt32(Request.QueryString["repMer"]);
                bool reported = client.reportMerchant(merchantID);
                themessageDiv.Visible = true;
                themessageDiv.InnerText = "REPORT SUBMITTED!";
            }
        }

        protected void SkipR(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void SaveNext(object sender, EventArgs e)
        {
            review = Page.Request.Form["newRev"];
            string stuNum = client.getStuNumber(Session["email"].ToString());
            int.TryParse(Page.Request.Form["rates"], out rating);
            bool rated = client.setRating(rating,stuNum,merchantID);
            bool reviewed = client.setReview(review,stuNum,merchantID);
            
            if(rated && reviewed)
            {
                bool israted = client.setIsRated(stuNum, merchantID, 1);
                Response.Redirect("Feedback.aspx?counter=" + counter);
            }
            else
            {
                themessageDiv.Visible = true;
                themessageDiv.InnerText = "Rating failed! try again";
            }
        }
    }
}