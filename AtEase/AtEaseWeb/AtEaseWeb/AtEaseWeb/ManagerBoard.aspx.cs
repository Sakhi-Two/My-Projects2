using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class ManagerBoard : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            MerchantClass[] Merchants = client.GetAllMerchants();
            string display = "";
            
                if (Merchants != null)
                {
                    if (Request.QueryString["remMerch"] != null)
                    {
                        bool removeF = client.removefromFeed(Convert.ToInt32(Request.QueryString["remMerch"].ToString()));
                        bool removeP = client.removeOwnerProducts(Convert.ToInt32(Request.QueryString["remMerch"].ToString()));
                        bool removed = client.removeMerchant(Convert.ToInt32(Request.QueryString["remMerch"].ToString()));
                        if (removed && removeF && removeP)
                        {
                            Response.Redirect("ManagerBoard.aspx");
                        }
                    }

                    foreach (MerchantClass m in Merchants)
                    {
                        int Rating = client.GetMerchRating(m.merchID);
                        display += "<tr>";
                        display += "<td>" + m.name + "</td>";
                        if (Rating == 0 || Rating == 1)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'>" + "</td>";
                        }
                        else if (Rating == 2)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                        }
                        else if (Rating == 3)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                        }
                        else if (Rating == 4)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                        }
                        else if (Rating == 5)
                        {
                            display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                        }
                        display += "<td>" + "<a href='Reviews.aspx?merchID=" + m.merchID + "'><p style='color:purple;'>Check</p></a>" + "</td>";
                        display += "<td>" + m.strikes + "</td>";
                        display += "<td class='shoping__cart__item__close'>";
                        display += "<a href='ManagerBoard.aspx?remMerch=" + m.merchID + "'><span class='glyphicon glyphicon-remove'></span></a>";
                        display += "</td>";
                        display += "</tr>";
                    }
                }
            table.InnerHtml = display;
        }

        protected void DefSort_Click(object sender, EventArgs e)
        {
            MerchantClass[] Merchants = client.GetAllMerchants();
            string display = "";
            if (Merchants != null)
            {
                foreach (MerchantClass m in Merchants)
                {
                    int Rating = client.GetMerchRating(m.merchID);
                    display += "<tr>";
                    display += "<td>" + m.name + "</td>";
                    if (Rating == 0 || Rating == 1)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (Rating == 2)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (Rating == 3)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    else if (Rating == 4)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (Rating == 5)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    display += "<td>" + "<a href='Reviews.aspx?merchID=" + m.merchID + "'>Check</a>" + "</td>";
                    display += "<td>" + m.strikes + "</td>";
                    display += "<td class='shoping__cart__item__close'>";
                    display += "<a href='ManagerBoard.aspx?remMerch=" + m.merchID + "'><span class='glyphicon glyphicon-remove'></span></a>";
                    display += "</td>";
                    display += "</tr>";
                }
            }
            table.InnerHtml = display;
        }

        protected void btnSortStrikes_Click(object sender, EventArgs e)
        {
            //Copy contents from array to List
            MerchantClass[] Merchants = client.GetAllMerchants();
            List<MerchantClass> theList = new List<MerchantClass>();
            foreach (MerchantClass mc in Merchants)
            {
                theList.Add(mc);
            }

            //Sort contents in the List
            SortStrike sortbyStrikes = new SortStrike();
            theList.Sort(sortbyStrikes);

            //Display contents in the list by ascending order of strikes
            string display = "";
            if (theList != null)
            {
                
                foreach (MerchantClass m in theList)
                {
                    int Rating = client.GetMerchRating(m.merchID);
                    display += "<tr>";
                    display += "<td>" + m.name + "</td>";
                    if (Rating == 0 || Rating == 1)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (Rating == 2)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (Rating == 3)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    else if (Rating == 4)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'>" + "</td>";
                    }
                    else if (Rating == 5)
                    {
                        display += "<td>" + "<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>" + "</td>";
                    }
                    display += "<td>" + "<a href='Reviews.aspx?merchID=" + m.merchID + "'>Check</a>" + "</td>";
                    display += "<td>" + m.strikes + "</td>";
                    display += "<td class='shoping__cart__item__close'>";
                    display += "<a href='ManagerBoard.aspx?remMerch=" + m.merchID + "'><span class='glyphicon glyphicon-remove'></span></a>";
                    display += "</td>";
                    display += "</tr>";
                }
            }
            table.InnerHtml = display;
        }
    }
    internal class SortStrike : IComparer<MerchantClass>
    {
        public int Compare(MerchantClass x, MerchantClass y)
        {
            return x.strikes.CompareTo(y.strikes);
        }
    }

}