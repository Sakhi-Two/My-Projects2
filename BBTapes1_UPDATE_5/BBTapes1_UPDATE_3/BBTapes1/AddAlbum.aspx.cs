using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BBTapes1.MyServiceReference;
using BBTapeService;

namespace BBTapes1
{
    public partial class AddAlbum : System.Web.UI.Page
    {
        BBTapesServiceClient BB = new BBTapesServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
          //  if (Session["Name"] == null)
           //{
               // Response.Redirect("Home.aspx");
            //}
           // else
           // {
               // if (!Session["UserType"].Equals("Management"))
               // {
                //    Response.Redirect("Home.aspx");
              //  }
           // }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            bool isNew = BB.NewAlbum(Convert.ToInt32(aID.Value));
            if(isNew == false)
            {
                var alb = new AlbumInfo
                {
                    releaseDate = rDate.Value,
                    artistID = Convert.ToInt32(arID.Value),
                    AlbumName = aName.Value,
                    price = Convert.ToDouble(aPrice.Value),
                    Images = img.Value,

                };
                var album = BB.AddAlbum(alb);
                if(album == true)
                {
                    themessageDiv.Visible = true;
                    themessage.Value = "New Album Added";
                }
            }
            else
            {
                themessageDiv.Visible = true;
                themessage.Value = "Album Already exists";
            }
        }
    }
}