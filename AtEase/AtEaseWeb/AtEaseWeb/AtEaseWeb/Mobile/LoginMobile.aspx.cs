using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb.Mobile
{
    public partial class LoginMobile : System.Web.UI.Page
    {
        AtEaseServiceClient SR = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser_Click(object sender, EventArgs e)
        {
            //***************************************STUDENTS LOGIN*************************************************\\

            int UserExist = SR.StudentLogin(email.Value, password.Value);
            if (UserExist == 1) //Student exists but has been inactive
            {
                Session["email"] = email.Value;
                Session["userType"] = "Student";
                if (!SR.checkStudentActive(email.Value))
                {
                    Response.Redirect("LoginOTP.aspx");
                }
            }
            else if (UserExist == 2) //Student exists and has been active
            {
                Session["email"] = email.Value;
                Session["userType"] = "Student";
                Response.Redirect("Home.aspx");
            }
            else //Student does not exist
            {
                themessageDiv.InnerText = "Email or Password incorrect";
                themessageDiv.Visible = true;
            }

            //***************************************MERCHANTS LOGIN*************************************************\\

            int UserExists = SR.MerchantLogin(email.Value, password.Value);

            if (UserExists == 1) //Merchant exists but has been inactive
            {
                Session["email"] = email.Value;
                Session["userType"] = "Merchant";
                if (!SR.checkMerchantActive(email.Value))
                    Response.Redirect("LoginOTP.aspx");
            }
            else if (UserExists == 2) //Merchant exists and is active
            {
                Session["email"] = email.Value;
                Session["userType"] = "Merchant";
                Response.Redirect("MerchantBoardMobile.aspx");
            }
            else //Merchant does not exist
            {
                themessageDiv.InnerText = "Email or Password incorrect";
                themessageDiv.Visible = true;
            }


            //***************************************MANAGER LOGIN*************************************************\\

            int UsersExist = SR.ManagerLogin(email.Value, password.Value);
            if (UsersExist == 1) //Manager exists
            {
                Session["email"] = email.Value;
                Session["userType"] = "Manager";
                Response.Redirect("ManagerBoard.aspx");
            }
            else //Manager does not exist
            {
                themessageDiv.InnerText = "Email or Password incorrect";
                themessageDiv.Visible = true;
            }

        }
    }
}