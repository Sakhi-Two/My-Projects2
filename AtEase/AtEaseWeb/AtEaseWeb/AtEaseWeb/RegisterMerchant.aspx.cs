using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class RegisterMerchant : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegMerch(object sender, EventArgs e)
        {
            //Check if account already exists
            if (client.IsMerchRegistered(email.Value))
            {
                feedback.Value = "The entered email already exists as part of another account";
            }
            else
            {
                // check if the password matches confirm password
                if (password.Value == confPassword.Value)
                {
                    MerchantClass s = new MerchantClass
                    {
                        
                        name = name.Value,
                        email = email.Value,
                        contact = contact.Value,
                        password = password.Value,
                    };
                    bool Registration = client.RegisterMerchant(s);

                    //check if operation was succesful and provide feedback
                    if (Registration)
                    {
                        feedback.Value = "You have succesfully been registered as a merchant";
                        name.Value = "";
                        email.Value = "";
                        contact.Value = "";
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        feedback.Value = "Operation was unsucessful, please try again";
                    }
                }
                else
                {
                    feedback.Value = "Password and confirm password do not match";
                }
            }
        }
    }
}