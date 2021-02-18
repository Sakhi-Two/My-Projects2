using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class HomeMobile : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string show = "";
            string lShow = "";
            string tShow = "";
            string mShow = "";

            BookClass[] book = client.GetHomeBooks();

            foreach (BookClass b in book)
            {
                show += "<div class='col-lg-3 col-md-4 col-sm-6 mix oranges fresh-meat'>";
                show += "<div class='featured__item'>";
                show += "<div class='featured__item__pic'>";
                show += "<img src=" + b.image + " width='300px' height='300px'>";
                show += "<ul class='featured__item__pic__hover'>";
                show += "<li><a href='SearchResults.aspx?SearchValue=" + b.isbn + "'><p>VIEW</p></a></li>";
                show += "</ul>";
                show += "</div>";
                show += "<div class='featured__item__text'>";
                show += "<h6><a href='SearchResults.aspx?SearchValue=" + b.isbn + "'>" + b.name + "</a></h6>";
                show += "</div>";
                show += "</div>";
                show += "</div>";
            }

            int counter = 0; //REMOVE THIS AFTERWARDS -- used to pick random books for displaying in a certain section. Use it right          ***NOTE***
            foreach (BookClass lb in book)
            {
                if (counter % 3 == 0)
                {
                    lShow += "<div class='latest-prdouct__slider__item'>";
                    lShow += "<a href='SearchResults.aspx?SearchValue=" + lb.isbn + "' class='latest-product__item'>";
                    lShow += "<div class='latest-product__item__pic'>";
                    lShow += "<img src=" + lb.image + " style='width:80px'>";
                    lShow += "</div>";
                    lShow += "<div class='latest-product__item__text'>";
                    lShow += "<h6>" + lb.name + "</h6>";
                    lShow += "</div>";
                    lShow += "</a>";
                    lShow += "</div>";
                }
                counter++;
            }
            counter = 0;

            foreach (BookClass tb in book)
            {
                if (counter % 2 == 0)
                {
                    tShow += "<div class='latest-prdouct__slider__item'>";
                    tShow += "<a href='SearchResults.aspx?SearchValue=" + tb.isbn + "' class='latest-product__item'>";
                    tShow += "<div class='latest-product__item__pic'>";
                    tShow += "<img src=" + tb.image + " style='width:60px'>";
                    tShow += "</div>";
                    tShow += "<div class='latest-product__item__text'>";
                    tShow += "<h6>" + tb.name + "</h6>";
                    tShow += "</div>";
                    tShow += "</a>";
                    tShow += "</div>";
                }
                counter++;
            }
            counter = 0;

            foreach (BookClass mb in book)
            {
                if (counter % 4 == 0)
                {
                    mShow += "<div class='latest-prdouct__slider__item'>";
                    mShow += "<a href='SearchResults.aspx?SearchValue=" + mb.isbn + "' class='latest-product__item'>";
                    mShow += "<div class='latest-product__item__pic'>";
                    mShow += "<img src=" + mb.image + " style='width:60px'>";
                    mShow += "</div>";
                    mShow += "<div class='latest-product__item__text'>";
                    mShow += "<h6>" + mb.name + "</h6>";
                    mShow += "</div>";
                    mShow += "</a>";
                    mShow += "</div>";
                }
                counter++;
            }

            books.InnerHtml = show;
            latest.InnerHtml = lShow;
            top.InnerHtml = tShow;
            mostBought.InnerHtml = mShow;
        }
    }
}