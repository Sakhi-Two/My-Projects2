using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class SingleBook : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pr = 0;
            int mID = 0;

                string show = "";
                string bShow = "";
                string isbn = Request.QueryString["isbn"];
                string merchID = Request.QueryString["merchID"];
                ProductClass pc = client.GetMerchProduct(isbn, merchID);
                BookClass bc = client.GetBook(isbn);
                MerchantClass mc = client.GetMerchant(Convert.ToInt32(merchID));

                bShow += "<div class='product__details__pic__item'>";
                bShow += "<img src="+pc.image+" width='400px' height='500px'>";
                bShow += "</div>";

                show+= "<div class='product__details__text'>";
                show += "<h3>"+ bc.name+ "</h3>";
                show += " <div class='product__details__price'> R"+ Math.Round(Convert.ToDecimal(pc.price), 2) + "</div>";
                show += "<p>Author: "+ bc.author + "</br>" +
                           "Edition: "+ bc.edition + "</br>" +
                        "</p>";
                show += "<ul>";
                show += "<h3>Merchant Details</h3>";
                show += "<p>Merchant Name: " + mc.name + "</br>" +
                           "Merchant Contact: " + mc.contact + "</br>" +
                           "Merchant Email: " + mc.email + "</br>" +
                        "</p>";
                show += "<li><b>Availability</b> <span>In Stock</span></li>";
                show += "</ul>";
                // show += "<a href='SingleBook.aspx?isbn=" + isbn + "&merchID=" + mc.merchID + "&reload=" + bc.name + "' class='primary-btn'>ADD TO CART</a>";
                show += "<div class='popup' onclick='myFunction()'><a href='SingleBook.aspx?isbn=" + isbn + "&merchID=" + mc.merchID + "&reload=" + bc.name + "' class='primary-btn'>ADD TO MY BOOKS</a>";
                show += "<span class='popuptext' id='myPopup'>";
                show += "<h4>Successfully Added The Book To Your Books</h4>";
                show += "</span>";
                show += "</div>";
                show += "";
                show += "</div>";

                pr = pc.price;
                mID = mc.merchID;

                book.InnerHtml = bShow;
                theBook.InnerHtml = show;

                
            
                if (Request.QueryString["reload"] != null)
                {
                    string stNum = client.getStuNumber(Session["email"].ToString());
                    isbn = Request.QueryString["isbn"];
                    QuotationClass quote = new QuotationClass
                    {
                        studentnum = stNum,
                        isbn = isbn,
                        date = DateTime.UtcNow,
                        price = pr,
                        merchID = mID
                    };
                    bool added = client.addtoQuote(quote);
                     
                    if (added)
                    {
                        //For cart icon
                         Session["CartTotal"] = Convert.ToDecimal(Session["CartTotal"]) + pr;
                        Session["CartItems"] = Convert.ToInt32(Session["CartItems"]) + 1;
                        
                        themessageDiv.Visible = true;
                        themessageDiv.InnerText = "Book Successfully Added To Quotation!";
                        Response.Redirect("SingleBook.aspx?isbn=" + isbn + "&merchID=" + merchID);
                    }
                    else
                    {
                        themessageDiv.Visible = true;
                        themessageDiv.InnerText = "Book Addition To Quotation Failed.";
                    }
                }
           
            

        }
    }
}