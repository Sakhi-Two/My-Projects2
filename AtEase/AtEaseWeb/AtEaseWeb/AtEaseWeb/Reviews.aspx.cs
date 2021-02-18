using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class Reviews : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mid = Request.QueryString["merchID"];
                int merchID;
                Int32.TryParse(mid, out merchID);
                string show = "";
                MerchantClass[] Merchants = client.GetAllMerchants();
                string[] review = client.GetMerchReviews(merchID);

                foreach (MerchantClass m in Merchants)
                {
                    if (m.merchID == merchID)
                    {
                        if (review != null)
                        {
                            //add for loop for reviews
                            foreach(string r in review)
                            {
                                show += "<div class='wrap-login100'>" +
                                    "<form class='login100-form validate-form'>" +
                                    "<span class='login100-form-title'>REVIEWS</span>" +
                                            "<table style='width:65%'>" +
                                            "<tr>" +
                                            "<th><img src ='img/ui.png' width='100px' height='100px'/></th>" +
                                            "<th><div class='box3 sb14'>" + r + "</div></th>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "<td>" + DateTime.Now + "</td>" +
                                            "</tr>" +
                                            "</table>" +
                                         "</form>" +
                                    "</div>";
                            }
                        }
                        else
                        {
                            show += "<h3> No Reviews yet </h3>";
                        }
                    }
                }
                feedback.InnerHtml = show;

            }
        }
    }
}