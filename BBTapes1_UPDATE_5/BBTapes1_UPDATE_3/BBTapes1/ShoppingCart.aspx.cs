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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        BBTapesServiceClient client = new BBTapesServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            UsersInfo user = client.getUsers(Session["Username"].ToString());
            dynamic CartAlbumID = client.getCartItems(user.userID);

            String display = "";
            
            if (!IsPostBack)
            {
                
               if (CartAlbumID != null)
               {
                    foreach (int c in CartAlbumID)
                    {
                    dynamic albumID = client.GetArtistAlbum(c);
                        if (albumID != null)
                        {
                            foreach (AlbumInfo a in albumID)
                            {

                                display += "<tr>";


                                display += "<tr>";
                                display += "<td><img src ='" + a.Images + "' width ='50' height = '50' /> </ td >";
                                display += "<td>" + a.AlbumName + "</td>";
                                display += " <td > In stock </td>";
                                display += "<td> ";
                                display += "<button style ='float:left;right:500px;' type='button' class='btn btn-default btn-number' data-type='minus' data-field='quant[1]'>";
                                display += "<span class='glyphicon glyphicon-minus'></span>";
                                display += "</button>";

                                display += "<input style ='width:10%;float:left;' type='text' name='quant[1]' class='form-control input-number' value='1' min='1' max='10'>";

                                display += "<button style ='float:left;' type='button' class='btn btn-default btn-number' data-type='plus' data-field='quant[1]'>";
                                display += "<span class='glyphicon glyphicon-plus'></span>";
                                display += "</button>";

                                display += "</td>";
                                display += "<td class='text-right'>" + a.price + "</td>";
                                display += "<td class='text-right'><button class='btn btn-sm btn-danger'><i class='fa fa-trash'>X</i> </button> </td>";
                                display += "</tr>";


                                display += "<tr>";
                                display += "<td></td>";
                                display += "<td></td>";
                                display += "<td></td>";
                                display += "<td></td>";
                                display += "<td>Sub-Total</td>";
                                display += "<td class='text-right'>255,90 €</td>";
                                display += "</tr>";
                               /* display += "< tr >";
                                display += "<td></td>";
                                display += "<td></td>";
                                display += "<td></td>";
                                display += "<td></td>";
                                display += "<td>Shipping</td>";
                                display += "<td class='text-right'>6,90 €</td>";
                                display += "</tr>";
                                display += "<tr>";
                                display += "<td></td>";
                                display += "<td></td>";
                                display += "< td ></ td >";
                                display += "<td></td>";
                                display += "<td><strong>Total</strong></td>";
                                display += "<td class='text-right'><strong>346,90 €</strong></td>";
                                display += " </tr>";
                                display += "</tr>";*/
                            }

                        }
                        shopItems.InnerHtml = display;
                        
                    }
                    Prices.Visible = true;



                    

                }

            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}