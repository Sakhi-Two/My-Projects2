using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class ManageStock : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        static string imgName = "";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //add the book
            if (Request.QueryString["mIsbn"] != null && Request.QueryString["mMerchID"] != null)
            {
               
                bool isNew = client.IsNewMerchBook(Request.QueryString["mIsbn"].ToString(), Convert.ToInt32(Request.QueryString["mMerchID"].ToString()));
                if (isNew == false)
                {
                    ProductClass merchantbook = new ProductClass
                    {
                        isbn = Request.QueryString["mIsbn"].ToString(),
                        merchID = Convert.ToInt32(Request.QueryString["mMerchID"].ToString()),
                        price = Convert.ToInt32(Request.QueryString["mPrice"].ToString()),
                        rating = 0,
                        reviews = "",
                        image = imgName
                    };
                    bool IsProductAdded = client.AddMerchProduct(merchantbook);

                    if (IsProductAdded == true)
                    {
                        string merchEmail = Session["email"].ToString();
                        int merchID = client.GetMerchID(merchEmail);
                        themessageDiv.Visible = true;
                        feedback.Value = "Book added to stock";
                        Response.Redirect("MerchantBoard.aspx");

                    }
                    else
                    {
                        themessageDiv.Visible = true;
                        feedback.Value = "Encountered problem!, Book not added";
                    }
                }
                else
                {
                    themessageDiv.Visible = true;
                    feedback.Value = "Book already in stock";
                }
            }
        }

        protected void UploadImg_Click(object sender, EventArgs e)
        {

        }
        protected void AddBook_Click(object sender, EventArgs e)
        {

            //Add book to products
            BookClass book = null;
            string merchEmail = Session["email"].ToString();
            int merchID = client.GetMerchID(merchEmail);
            bool IsCorrect = client.SearchBook(isbn.Value);
            string show = "";
            if (IsCorrect == true)
            {
                if (theImage.HasFile)
                {
                    imgName = "\\img\\" + theImage.FileName;
                    theImage.SaveAs(Server.MapPath(imgName));
                    lblImg.Text = "Image Uploaded";
                    lblImg.ForeColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lblImg.Text = "Please Select your file";
                    lblImg.ForeColor = System.Drawing.Color.Red;
                }

                btnConfirm.Visible = false;
                book = client.GetBook(isbn.Value);
                show += "<div class='popup' onclick='myFunction()'><button type='button' style='color: #9400D3;'>CONFIRM BOOK</button>";
                show += "<span class='popuptext' id='myPopup'>";
                show += "<p style='color: white;'>IS THIS THE BOOK YOU WANT TO ADD?</b></p>";
                show += "<img src=" + book.image + " width='60px' height='60px'/>";
                show += "<p style='color: black;'><b> Name: " + book.name + "</b></p>";
                show += "<p style='color: black;'><b> Author:" + book.author + "</b></p>";
                show += "<p style='color: black;'><b> Edition:" + book.edition + "</b></p>";
                show += "<a href='ManageStock.aspx?mIsbn=" + isbn.Value + "&mMerchID=" + merchID + "&mPrice=" + theprice.Value + "' class='primary-btn'>CONFIRM</a>";
                show += "</span>";
                show += "</div>";
                mypop.InnerHtml = show;

            }
            else
            {
                themessageDiv.Visible = true;
                feedback.Value = "ISBN does not exist, Enter correct ISBN";
            }
        }
    }
}