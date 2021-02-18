using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class SiteMaster : MasterPage
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";
            if (Session["userType"] != null)
            {
                userType = Session["userType"].ToString();
            }

            string show = "";
            string hShow = "";
            string cartShow = "";
            string categoriesShow = "";
            string nShow = "";
            double amount = 0;
            int numItems = 0;
            int strikes = 0;

            string url = System.IO.Path.GetFileName(Request.Url.AbsolutePath); //Current page

            if (Session["email"] != null && (Convert.ToInt32(Request.QueryString["loginStatus"]) != 0 || Request.QueryString["loginStatus"] == null))
            {
                //Login Status Dynamic Display
                if (url == "Login" || url == "Register" || url == "RegisterStudent" || url == "RegisterMerchant")
                {
                    menu.Visible = false;
                    hero.Visible = false;
                    footer.Visible = true;
                    loggedIn.Visible = false;
                    loggedOut.Visible = false;
                    hLoggedIn.Visible = false;
                    hLoggedOut.Visible = false;
                    hCart.Visible = false;
                }
                else
                {

                    decimal totPrice = 0;
                    int totItems = 0;
                    QuotationClass[] quote = client.getQuoteInfo(client.getStuNumber(Session["email"].ToString()));

                    foreach(QuotationClass q in quote)
                    {
                        totPrice += q.price;
                        totItems++;
                    }

                    Session["CartTotal"] = totPrice;
                    Session["CartItems"] = totItems;

                    amount = Math.Round(Convert.ToDouble(Session["CartTotal"]), 2);
                    numItems = Convert.ToInt32(Session["CartItems"]);

                    //Display cart information
                    cart.Visible = true;
                    show += "<ul>";
                    show += "<li>";
                    show += "<a href='BookCart.aspx'><i class='glyphicon glyphicon-book'></i>";
                    show += "<span>" + numItems + "</span>";
                    show += "</a>";
                    show += "</li>";
                    show += "</ul>";
                    show += "<div class='header__cart__price'>Books:R <span>" + amount + "</span></div>";

                    loggedIn.Visible = true;
                    loggedOut.Visible = false;
                    hLoggedIn.Visible = true;
                    hLoggedOut.Visible = false;
                    hCart.Visible = true;

                    //Mobile
                    show += "<div class='header__top__right__auth'>";
                    show += "<a href='Login.aspx?loginStatus=" + 0 + "'><i class='glyphicon glyphicon-user'></i>Logout</a>";
                    show += "</div>";

                    //Desktop
                    hShow += "<div class='header__top__right'>";
                    hShow += "<div class='header__top__right__auth'>";
                    hShow += "<a href='Login.aspx?loginStatus=" + 0 + "'><i class='glyphicon glyphicon-user'></i>Logout</a>";
                    hShow += "</div>";
                    hShow += "</div>";

                    cartShow += "<ul>";
                    cartShow += "<li>";
                    cartShow += "<a href='BookCart.aspx'><i class='glyphicon glyphicon-book'></i>";
                    cartShow += "<span>" + numItems + "</span>";
                    cartShow += "</a>";
                    cartShow += "</li>";
                    cartShow += "</ul>";
                    cartShow += "<div class='header__cart__price'>Books: <b>R</b><span>" + amount + "</span></div>";

                    loggedIn.InnerHtml = show;
                    hLoggedIn.InnerHtml = hShow;
                    hCart.InnerHtml = cartShow;
                }

                //User Type Dynamic Display
                if(userType == "Manager")
                {
                    hero.Visible = true;
                    categories.Visible = true;
                    categoriesShow += "<div class='hero__categories__all'>";
                    categoriesShow += "<i class='glyphicon glyphicon-menu-hamburger'></i>";
                    categoriesShow += "<span>Options</span>";
                    categoriesShow += "</div>";
                    categoriesShow += "<ul>";
                    categoriesShow += "<li><a href='#'>Dashboard</a></li>";
                    categoriesShow += "<li><a href='#'>option 2</a></li>";
                    categoriesShow += "<li><a href='#'>option 3</a></li>";
                    categoriesShow += "</ul>";
                }
                else if(userType == "Student")
                {
                    hero.Visible = true;
                    categories.Visible = true;
                    categoriesShow += "<div class='hero__categories__all'>";
                    categoriesShow += "<i class='glyphicon glyphicon-menu-hamburger'></i>";
                    categoriesShow += "<span>Options</span>";
                    categoriesShow += "</div>";
                    categoriesShow += "<ul>";
                    categoriesShow += "<li><a href='EditStudent.aspx'>Edit Profile</a></li>";
                    categoriesShow += "</ul>";
                }
                else if(userType == "Merchant")
                {
                    string mShow = "";
                    string mID = Session["email"].ToString();
                    hero.Visible = true;
                    categories.Visible = true;
                    hCart.Visible = false;
                    mChat.Visible = true;
                    mNotify.Visible = true;
                    btnBookSearch.Visible = false;
                    searchBar.Visible = false;
                    categoriesShow += "<div class='hero__categories__all'>";
                    categoriesShow += "<i class='glyphicon glyphicon-menu-hamburger'></i>";
                    categoriesShow += "<span>Options</span>";
                    categoriesShow += "</div>";
                    categoriesShow += "<ul>";
                    categoriesShow += "<li><a href='MerchantBoard.aspx'>Dashboard</a></li>";
                    categoriesShow += "<li><a href='EditMerchant.aspx'>Edit Details</a></li>";
                    categoriesShow += "<li><a href='ManageStock.aspx'>Manage Stock</a></li>";
                    categoriesShow += "<li><a href='Reviews.aspx?merchID=" + mID + "'>Reviews</a></li>";
                    categoriesShow += "</ul>";

                    
                    mShow += "<ul>";
                    mShow += "<li>";
                    mShow += "<a href='/Chat/SignalRChat/chatRoom.html'><i class='glyphicon glyphicon-comment'></i>";
                    mShow += "</a>";
                    mShow += "</li>";
                    mShow += "</ul>";
                    mShow += "<div class='header__cart__price'><span>Go to chat</span></div>";
                    mChat.InnerHtml = mShow;

                    int merchID = client.GetMerchID(mID);
                    MerchantClass m = client.GetMerchant(merchID);
                    nShow += "<ul>";
                    nShow += "<li>";
                    nShow += "<a href='Notifications.aspx'><i class='glyphicon glyphicon-exclamation-sign'></i>";
                    nShow += "<span>" + m.strikes + "</span>";
                    nShow += "</a>";
                    nShow += "</li>";
                    nShow += "</ul>";
                    nShow += "<div class='header__cart__price'><span>Notifications</span></div>";
                    mNotify.InnerHtml = nShow;
                }
                categories.InnerHtml = categoriesShow;
                

            }
            else if(Convert.ToInt32(Request.QueryString["loginStatus"]) == 0 || Session["email"] == null)
            {
                Session["email"] = null; //Ensure that user is indeed logged out

                if (url == "Login" || url == "Register" || url == "RegisterStudent" || url == "RegisterMerchant")
                {
                    menu.Visible = false;
                    hero.Visible = false;
                    footer.Visible = true;
                    loggedIn.Visible = false;
                    loggedOut.Visible = false;
                    hLoggedIn.Visible = false;
                    hLoggedOut.Visible = false;
                    hCart.Visible = false;
                    mNotify.Visible = false;
                }
                else
                {
                    loggedIn.Visible = false;
                    loggedOut.Visible = true;
                    hLoggedIn.Visible = false;
                    hLoggedOut.Visible = true;
                    hCart.Visible = false;
                    mNotify.Visible = false;

                    //Mobile
                    show += "<div class='header__top__right__auth'>";
                    show += "<a href='Login.aspx'><i class='glyphicon glyphicon-user'></i>Login</a>";
                    show += "</div>";
                    show += "<div class='header__top__right__auth'>";
                    show += "<a href='Register.aspx'><i class='glyphicon glyphicon-user'></i>Register</a>";
                    show += "</div>";

                    //Desktop
                    hShow += "<div class='header__top__right'>";
                    hShow += "<div class='header__top__right__auth'>";
                    hShow += "<a href='Login.aspx'><i class='glyphicon glyphicon-user'></i>Login</a>";
                    hShow += "</div>";
                    hShow += "<div class='header__top__right__auth'>";
                    hShow += "<a href='Register.aspx'><i class='glyphicon glyphicon-user'></i>Register</a>";
                    hShow += "</div>";
                    hShow += "</div>";

                    loggedOut.InnerHtml = show;
                    hLoggedOut.InnerHtml = hShow;
                }
            }
        }

        protected void SearchBook(object sender, EventArgs e)
        {
            bool GotBook = client.SearchBook(searchBar.Value);
            if (GotBook == true)
            {
                Response.Redirect("SearchResults.aspx?SearchValue=" + searchBar.Value);
            }
            else
            {
                searchBar.Value = "";
            }
        }
    }
}