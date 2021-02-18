using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class BookCart : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string stuNum = client.getStuNumber(Session["email"].ToString());
            QuotationClass[] quote = client.getQuoteInfo(stuNum);
            
            MerchantClass mer = null;
            BookClass book = null;
            int merchantID;
            string show = "";
            decimal? total = 0;
            int index = 0;

            foreach(QuotationClass q in quote)
            {
                book = client.GetBook(q.isbn);
                merchantID = q.merchID ?? default(int);
                mer = client.GetMerchant(merchantID);
                
                show += "<tr>";
                show += "<td class='shoping__cart__item'>";
                show += "<img src="+book.image+" height='40' width='40' alt=''>";
                show += "<h5>" + book.name + "</h5>";
                show += "</td>";
                show += "<td><h5>" + mer.name + "</h5></td>";
                show += "<td class='shoping__cart__price'>" + q.price + "</td>";
                show += "<td class='shoping__cart__item__close'>";
                show += "<a href='BookCart.aspx?remISBN="+ book.isbn +"&remMerch="+ mer.merchID+"&remPrice="+q.price+ "'><span class='glyphicon glyphicon-remove'></span></a>";
                show += "</td>";
                show += "</tr>";
                total += q.price;
                index++;
            }
            index = 0;
            table.InnerHtml = show;
            
            show = "";
            show += "<div class='shoping__checkout'>";
            show += "<h5>My Books' Total</h5>";
            show += "<ul>";
            show += "<li>Subtotal<span>R"+Math.Round(Convert.ToDouble(total),2)+"</span></li>";
            show += "</ul>";
            show += "<a href='Checkout.aspx?stuNum="+stuNum+"' class='primary-btn'>PROCEED TO ACQUISITION</a>";
            show += "</div>";
            cartTotal.InnerHtml = show;

            if(Request.QueryString["remISBN"] != null && Request.QueryString["remMerch"] != null && Request.QueryString["remPrice"] != null)
            {
                string rem = Request.QueryString["remISBN"].ToString();
                decimal pr = Convert.ToDecimal(Request.QueryString["remPrice"]);
                int merch = Convert.ToInt32(Request.QueryString["remMerch"]);

                //For cart icon
                if (Convert.ToDecimal(Session["CartTotal"]) - pr >= 0 && Convert.ToInt32(Session["CartItems"]) - 1 >= 0)
                {
                    Session["CartTotal"] = Convert.ToDecimal(Session["CartTotal"]) - pr;
                    Session["CartItems"] = Convert.ToInt32(Session["CartItems"]) - 1;
                }
                else
                {
                    Session["CartTotal"] = 0;
                    Session["CartItems"] = 0;
                }

                bool removed = client.removeFromQuote(rem, merch);
                Response.Redirect("BookCart.aspx");
            }
        }

        protected void DownloadQuote(object sender, EventArgs e)
        {
            string stuNum = client.getStuNumber(Session["email"].ToString());
            MigraDoc.DocumentObjectModel.Document doc = new MigraDoc.DocumentObjectModel.Document();
            MigraDoc.DocumentObjectModel.Section sec = doc.AddSection();
            MigraDoc.DocumentObjectModel.Shapes.Image img = sec.AddImage(Server.MapPath("~/img/logoPic.png"));
            img.LockAspectRatio = true;
            img.Width = 70;
            img.Height = 45;
            sec.AddParagraph("Focus On The Important.");
            sec.AddParagraph(" ");
            sec.AddParagraph("INVOICE FOR " + stuNum);
            sec.AddParagraph(" ");
            QuotationClass[] quotation = client.getQuoteInfo(stuNum);

            //create table
            MigraDoc.DocumentObjectModel.Tables.Table table = new MigraDoc.DocumentObjectModel.Tables.Table();
            table.Borders.Width = 0.5;

            //def column
            MigraDoc.DocumentObjectModel.Tables.Column column = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(7));
            column.Format.Alignment =  MigraDoc.DocumentObjectModel.ParagraphAlignment.Center;

            column = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(5));
            column.Format.Alignment = MigraDoc.DocumentObjectModel.ParagraphAlignment.Center;
            column = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(5));
            column.Format.Alignment = MigraDoc.DocumentObjectModel.ParagraphAlignment.Center;

            //create header of table
            MigraDoc.DocumentObjectModel.Tables.Row row = table.AddRow();
            MigraDoc.DocumentObjectModel.Tables.Cell cell = row.Cells[0];
            cell.AddParagraph("Books");
            cell.Format.Font.Bold = true;

            cell = row.Cells[1];
            cell.AddParagraph("Merchant");
            cell.Format.Font.Bold = true;

            cell = row.Cells[2];
            cell.AddParagraph("Cost");
            cell.Format.Font.Bold = true;

            decimal total = 0;

            foreach (QuotationClass q in quotation)
            {
                row = table.AddRow();

                BookClass book = client.GetBook(q.isbn);
                MerchantClass merchant = client.GetMerchant(Convert.ToInt32(q.merchID));

                cell = row.Cells[0];
                cell.AddParagraph(book.name);

                cell = row.Cells[1];
                cell.AddParagraph(merchant.name);

                cell = row.Cells[2];
                cell.AddParagraph(Math.Round(Convert.ToDecimal(q.price), 2).ToString());

                total += q.price;
            }

            row = table.AddRow();

            cell = row.Cells[2];
            cell.AddParagraph("Total Cost");
            cell.Format.Font.Bold = true;

            cell = row.Cells[2];
            cell.AddParagraph(total.ToString());

            //Add document to table
            doc.LastSection.Add(table);

            sec.AddParagraph("CONTACT US:");
            sec.AddParagraph("Tel: +27766709919");
            sec.AddParagraph("Email: ateaseadmin@freefall.com");
            sec.AddParagraph("Address: 100 Aberdeen, Westdene Suburbs, Johannesburg, 2092");

            //Rendering doc
            MigraDoc.Rendering.PdfDocumentRenderer docRend = new MigraDoc.Rendering.PdfDocumentRenderer(false);
            docRend.Document = doc;
            docRend.RenderDocument();

         
            //string filename = "Quotation.pdf";

            // Send PDF to browser
            MemoryStream stream = new MemoryStream();
            docRend.Save(stream, false);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", stream.Length.ToString());
            Response.BinaryWrite(stream.ToArray());
            Response.Flush();
            stream.Close();
            Response.End();

            /*/Open file in default app
            System.Diagnostics.ProcessStartInfo process = new System.Diagnostics.ProcessStartInfo();
            process.FileName = filename;

            System.Diagnostics.Process.Start(process);*/
            
        }

        protected void ClearQuote(object sender, EventArgs e)
        {
            string stuNum = client.getStuNumber(Session["email"].ToString());
            QuotationClass[] quote = client.getQuoteInfo(stuNum);
            
            foreach(QuotationClass q in quote)
            {   
                FeedbackClass fb = new FeedbackClass
                {
                    merchID = q.merchID ?? default(int),
                    stuNum = stuNum,
                    rating = 0,
                    review = "",
                    isRated = 0
                };
                client.setFeedback(fb);
                client.removeFromQuote(q.isbn, (q.merchID ?? default(int)));
            }
            int counter = -1;
            Response.Redirect("Feedback.aspx?counter="+counter);
        }

        protected void ClearHome(object sender, EventArgs e)
        {
            string stuNum = client.getStuNumber(Session["email"].ToString());
            QuotationClass[] quote = client.getQuoteInfo(stuNum);

            foreach (QuotationClass q in quote)
            {
                client.removeFromQuote(q.isbn, (q.merchID ?? default(int)));
            }
            Response.Redirect("Home.aspx");
        }
    }
}