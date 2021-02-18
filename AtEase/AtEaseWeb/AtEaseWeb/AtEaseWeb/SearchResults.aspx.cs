using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class SearchResults : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // 
            if (!IsPostBack)
            {
                MerchantClass mer = null;
                string show = "";
                string pShow = "";
                string theISBN = Request.QueryString["SearchValue"];
                BookClass thebook = client.GetBook(theISBN);
                ProductClass[] Merchs = client.GetProductMerchants(thebook.isbn);

                show += "<div style='margin: auto'>";
                show += "<div class='product__item__pic'><img src=" + thebook.image + " width='300px' height='300px'></div>";
                show += "<h5><b>ISBN</b>: " + thebook.isbn + "</h5>";
                show += "<h5 style='word-wrap: break-word; white-space: normal;'><b>Name</b>: " + thebook.name + "</h5>";
                show += "<h5><b>Edition</b>: " + thebook.edition + "</h5>";
                show += "<h5><b>Author</b>: " + thebook.author + "</h5>";
                show += "</div>";

                if (Merchs != null)
                {
                    foreach (ProductClass pc in Merchs)
                    {
                        mer = client.GetMerchant(pc.merchID);
                        pShow += "<div class='col' style='width=33%;'>";
                        pShow += "<div style='display: inline-block'>";
                        pShow += "<a href='SingleBook.aspx?isbn=" + thebook.isbn + "&merchID=" + mer.merchID + "'><img src=" + mer.image + " width='60' height='60'></a>";
                        pShow += "<p><b>Name: </b>" + mer.name + "</p>";
                        pShow += "<p><b>Price:</b> R" + Math.Round(Convert.ToDecimal(pc.price), 2) + "</p>";
                        pShow += "</div>";
                        pShow += "</div>";
                        //pShow += "<p>Merchant Rating: " + mer.rating + "</p>";

                    }
                }
                else
                {
                    pShow += "<h4>Opps... No Merchants Currently Have This Book In Stock. Please Check Again Later.</h4>";
                }
                mainBook.InnerHtml = show;
                product.InnerHtml = pShow;
            }
        }
    }
}