using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BBTapes1.MyServiceReference;
namespace BBTapes1
{
    public partial class DeleteAlbum : System.Web.UI.Page
    {
        BBTapesServiceClient client = new BBTapesServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            bool isDeleted = client.DeleteAlbum(Convert.ToInt32(delID.Value));
            if (isDeleted)
            {
                themessageDiv.Visible = true;
                themessage.Value = "Album Deleted!";
            }
            else
            {
                themessageDiv.Visible = true;
                themessage.Value = "Album Does Not Exist!";
            }
        }
    }
}