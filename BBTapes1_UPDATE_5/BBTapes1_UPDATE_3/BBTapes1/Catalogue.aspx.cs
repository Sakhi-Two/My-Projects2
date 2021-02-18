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
    public partial class Catalogue : System.Web.UI.Page
    {
        BBTapesServiceClient client = new BBTapesServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int ArtistType = Convert.ToInt32(Request.QueryString["ArtistType"]);
                dynamic artist =client.getArtists(ArtistType);
                string display = "";
                string header = "";
                if (ArtistType == 1)
                {
                    header = "Old School";
                }
                else
                {
                    header = "New School";
                }
                Musictype.InnerText = header;
                foreach (ArtistInfo a in artist)
                {
                    display +="<div class='col-lg-4 col-md-6'>";
                   display +="<a href='AboutProduct.aspx?ID="+a.artist_ID+"'>";
                    display += "<div class='promo-box set-bg' data-setbg='"+a.artist_image+"'>";
					display+= "<h4 style='color:yellow;'><center>"+a.artist_SN+"</center></h4>";
                   display += "</div>";
                  display += "</a>";
                    display += "</div>";
                }
                Images.InnerHtml = display;
            }
        }
    }
}