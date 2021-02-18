using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class EditMerchant : System.Web.UI.Page
    {
        AtEaseServiceClient serve = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //find merchant
            MerchantClass mer = null;
            String email = Convert.ToString(Session["email"]);
            //Get single merchant.
            int merchID = serve.GetMerchID(email);
            mer = serve.GetMerchant(merchID);
            if (serve.IsMerchRegistered(email) == true)
            {
                name.Value = mer.name;
                mail.Value = mer.email;
                contact.Value = mer.contact;
            }
        }

        protected void btnEdit(object sender, EventArgs e)
        {
            MerchantClass mer = new MerchantClass();

            mer.name = name.Value;
            mer.email = mail.Value;
            mer.contact = contact.Value;
            
            if (serve.EditMerchant(mer, mail.Value))
            {
                Response.Redirect("MerchantBoard.aspx");
                themessageDiv.InnerText = "Edit Success!";
            }
            else
            {
                themessageDiv.InnerText = "Edit Failed!";
            }
        }
    }
}