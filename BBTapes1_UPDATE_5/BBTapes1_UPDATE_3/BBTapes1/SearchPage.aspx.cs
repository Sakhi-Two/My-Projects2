using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BBTapes1.MyServiceReference;
namespace BBTapes1
{
    public partial class SearchPage : System.Web.UI.Page
    {
        BBTapesServiceClient BB = new BBTapesServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bool foundAlbum = BB.SearchAlbum(Convert.ToInt32(aID.Value));
            if (foundAlbum == true)
            {
                Response.Redirect("EditAlbum.aspx?ID=" + aID.Value);
            }
            else
            {
                aID.Value = " ";
            }
        }
    }
}