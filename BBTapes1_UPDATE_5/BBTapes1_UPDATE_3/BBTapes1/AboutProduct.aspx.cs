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
    public partial class AboutProduct : System.Web.UI.Page
    {
        BBTapesServiceClient client = new BBTapesServiceClient();

        public void AddBtn()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int AlbumID;
            if (!IsPostBack)
            {
                int ArtistID = Convert.ToInt32(Request.QueryString["ID"]);
                dynamic artistAlbum = client.GetArtistAlbum(ArtistID);
                
               string display = "";
                string header = "";
                UsersInfo user = client.getUsers(Session["Username"].ToString());
                header = client.getArtistName(ArtistID);
                Musictype.InnerText = header;
                foreach (AlbumInfo a in artistAlbum)
                {
                    display += "<div class='col-lg-4 col-md-6'>";

                    display += "<a href='ShoppingCart.aspx?ID=" + a.artistID + "'>";
                    display += "<div>" +"<center>"+"<img src=" + a.Images  + ">" + "</center>";
                    display += "<h5 style='color:white;'><center><b>" + "Album Name: </b><i>"  + a.AlbumName + "</i></center></h4>";
                    display += "<h5 style='color:#FFE400;'><center><b>" + "Release Date: </b><i>" + a.releaseDate + "</i></center></h4>";
                    display += "<h5 style='color:white;'><center><b>" + "Price: </b><i>" + "R" + a.price + "</i></center></h4>";
                    display += "</div>";
                    display += "</a>";
                    display += "</div>";

                    if(Session["Username"] != null)
                    {
                        display += "<div>";
                        display += "<h3><b>Quantity</b></h3><br>";
                        display += "<input type='number' placeholder='Quantity' height='4' width='4'></input>";
                       
                        display += "<br><br>";
                      
                        display += "<a href='AboutProduct.aspx?ID="+ArtistID+"&AlbumID="+a.AlbumID+"'><button style='border-radius:200px;' class='bt' type='button' onClick='AddBtn()' runat='server'>" + "<center>" + "Add To Cart" + "</center>" + "</ button ></a>";
                        display += "</div>";
                    }
                    AlbumID = Convert.ToInt32(Request.QueryString["AlbumID"]);
                    CartInfo cart = new CartInfo
                    {
                        albumID = AlbumID,
                        userID = user.userID
                    };
                    bool add = client.AddToCart(cart);
                }
                Images.InnerHtml = display;
             
             
            }
        }
    }
}