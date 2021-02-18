using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class MerchantBoard : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        static int pr = 0;

        protected void Save_Click(object sender, EventArgs e)
        {
            string merchEmail = Session["email"].ToString();
            int merchID = client.GetMerchID(merchEmail);
            int.TryParse(Page.Request.Form["newPrice"], out pr);
            bool priceSaved = client.SetMerchPrice(pr, Request.QueryString["SearchValue"].ToString(), merchID);
            if(priceSaved)
            {
                Response.Redirect("MerchantBoard.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string merchEmail = Session["email"].ToString();
            int merchID = client.GetMerchID(merchEmail);
            ProductClass[] books = client.AllMerchProducts(merchID);
            string display = "";
            //Innerhtml button
            Button btnSave = new Button();
            btnSave.ID = "savePrice";
            btnSave.Text = "Save";
            btnSave.Click += new EventHandler(this.Save_Click);
            saveP.Controls.Add(btnSave);
            saveP.Visible = false;
           
            
            if (Request.QueryString["remISBN"] != null)
            {
                bool removed = client.removeMerchProduct(Request.QueryString["remISBN"].ToString(), merchID);
                Response.Redirect("MerchantBoard.aspx");
            }

            if(Request.QueryString["SearchValue"] != null)
            {
                saveP.Visible = true;
                foreach (ProductClass mb in books)
                {
                    BookClass theBook = client.GetBook(Request.QueryString["SearchValue"].ToString());
                    if (mb.isbn == Request.QueryString["SearchValue"].ToString())
                    {
                        display += "<tr>";
                        display += "<td><div id='bookName'><img src=" + theBook.image + " width='30' height='30'></div></td>";
                        display += "<td>" + theBook.name + "</td>";
                        if (mb.rating == 0 || mb.rating == 1)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'>" + "</td>";
                        }
                        else if (mb.rating == 2)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                        }
                        else if (mb.rating == 3)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                        }
                        else if (mb.rating == 4)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                        }
                        else if (mb.rating == 5)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                        }
                        display += "<td>" + mb.price;
                        display += "<br/>";
                        display += "<div class='popup' onclick='myFunction()'><p><b>EDIT PRICE</b></p>";
                        display += "<span class='popuptext' id='myPopup'>";
                        display += "<h5>EDIT PRICE</h5>";
                        display += "<input type='text' name='newPrice' placeholder='Enter New Price' id='newPrice' runat='server'>";
                        display += "</span>";
                        display += "</div>";
                        display += "</td>";
                        display += "<td class='shoping__cart__item__close'>";
                        display += "<a href='MerchantBoard.aspx?remISBN=" + mb.isbn + "'><span class='glyphicon glyphicon-remove'></span></a>";
                        display += "</td>";
                        display += "</tr>";
                    }
                    table.InnerHtml = display;
                }
            }
            else
            {
                if (books != null)
                {
                    foreach (ProductClass mb in books)
                    {
                        BookClass theBook = client.GetBook(mb.isbn);
                        display += "<tr>";
                        display += "<td><img src=" + theBook.image + " width='30' height='30'></td>";
                        display += "<td><div id='bookName'>" + theBook.name + "</div></td>";
                        if (mb.rating == 0 || mb.rating == 1)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'>" + "</td>";
                        }
                        else if (mb.rating == 2)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                        }
                        else if (mb.rating == 3)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                        }
                        else if (mb.rating == 4)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                        }
                        else if (mb.rating == 5)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                        }
                        display += "<td>" + mb.price;
                        display += "</td>";
                        display += "<td class='shoping__cart__item__close'>";
                        display += "<a href='MerchantBoard.aspx?remISBN=" + mb.isbn + "'><span class='glyphicon glyphicon-remove'></span></a>";
                        display += "</td>";
                    }
                }
                table.InnerHtml = display;
            }
        }

        //Set to default order
        protected void btnSortDef_Click(object sender, EventArgs e)
        {
            string merchEmail = Session["email"].ToString();
            int merchID = client.GetMerchID(merchEmail);
            ProductClass[] books = client.AllMerchProducts(merchID);
            string display = "";

            if (books != null)
            {
                foreach (ProductClass mb in books)
                {
                    BookClass theBook = client.GetBook(mb.isbn);
                    display += "<tr>";
                    display += "<td><img src=" + theBook.image + " width='30' height='30'></td>";
                    display += "<td>" + theBook.name + "</td>";
                    if (mb.rating == 0 || mb.rating == 1)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (mb.rating == 2)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (mb.rating == 3)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    else if (mb.rating == 4)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (mb.rating == 5)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    display += "<td>" + mb.price;
                    display += "</td>";
                    display += "<td class='shoping__cart__item__close'>";
                    display += "<a href='MerchantBoard.aspx?remISBN=" + mb.isbn + "'><span class='glyphicon glyphicon-remove'></span></a>";
                    display += "</td>";
                }
            }
            table.InnerHtml = display;
        }
        //Set by order of rating
        protected void btnSortRate_Click(object sender, EventArgs e)
        {
            //Copy contents from array to list
            string merchEmail = Session["email"].ToString();
            int merchID = client.GetMerchID(merchEmail);
            ProductClass[] books = client.AllMerchProducts(merchID);
            List<ProductClass> theList = new List<ProductClass>();
            foreach (ProductClass mbc in books)
            {
                theList.Add(mbc);
            }
            //Sort list by rating
            SortRate sortbyRate = new SortRate();
            theList.Sort(sortbyRate);
            //Display contents in ascending order
            string display = "";

            if (theList != null)
            {
                foreach (ProductClass mb in theList)
                {
                    BookClass theBook = client.GetBook(mb.isbn);
                    display += "<tr>";
                    display += "<td><img src=" + theBook.image + " width='30' height='30'></td>";
                    display += "<td>" + theBook.name + "</td>";
                    if (mb.rating == 0 || mb.rating == 1)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (mb.rating == 2)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (mb.rating == 3)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    else if (mb.rating == 4)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (mb.rating == 5)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    display += "<td>" + mb.price;
                    display += "</td>";
                    display += "<td class='shoping__cart__item__close'>";
                    display += "<a href='MerchantBoard.aspx?remISBN=" + mb.isbn + "'><span class='glyphicon glyphicon-remove'></span></a>";
                    display += "</td>";

                }

               
            }
            table.InnerHtml = display;
        }

        //Set by order of price
        protected void btnSortPrice_Click(object sender, EventArgs e)
        {
            //Copy contents from array to list
            string merchEmail = Session["email"].ToString();
            int merchID = client.GetMerchID(merchEmail);
            ProductClass[] books = client.AllMerchProducts(merchID);
            List<ProductClass> theList = new List<ProductClass>();
            foreach (ProductClass mbc in books)
            {
                theList.Add(mbc);
            }
            //Sort list by rating
            SortPrice sortbyPrice = new SortPrice();
            theList.Sort(sortbyPrice);
            //Display contents in ascending order
            string display = "";

            if (theList != null)
            {
                foreach (ProductClass mb in theList)
                {
                    BookClass theBook = client.GetBook(mb.isbn);
                    display += "<tr>";
                    display += "<td><img src=" + theBook.image + " width='30' height='30'></td>";
                    display += "<td>" + theBook.name + "</td>";
                    if (mb.rating == 0 || mb.rating == 1)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (mb.rating == 2)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (mb.rating == 3)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    else if (mb.rating == 4)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (mb.rating == 5)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    display += "<td>" + mb.price;
                    display += "</td>";
                    display += "<td class='shoping__cart__item__close'>";
                    display += "<a href='MerchantBoard.aspx?remISBN=" + mb.isbn + "'><span class='glyphicon glyphicon-remove'></span></a>";
                    display += "</td>";

                }

            }
            table.InnerHtml = display;
        }

        protected void SearchBook(object sender, EventArgs e)
        {
            bool GotBook = client.SearchBook(searchBar.Value);
            if (GotBook == true)
            {
                Response.Redirect("MerchantBoard.aspx?SearchValue=" + searchBar.Value);
            }
            else
            {
                searchBar.Value = "";
            }
        }
    }

    internal class SortPrice : IComparer<ProductClass>
    {
        public int Compare(ProductClass x, ProductClass y)
        {
            return Convert.ToInt32(x.price).CompareTo(Convert.ToInt32(y.price));
        }

    }

   
    internal class SortRate : IComparer<ProductClass>
    {
        public int Compare(ProductClass x, ProductClass y)
        {
            return x.rating.CompareTo(y.rating);
        }

    }
}

