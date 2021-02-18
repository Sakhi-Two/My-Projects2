using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtEaseWeb.AtEaseService;

namespace AtEaseWeb
{
    public partial class Register : System.Web.UI.Page
    {
        AtEaseServiceClient client = new AtEaseServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegStu(object sender, EventArgs e)
        {
            //Check if account already exists
            if (client.IsStuRegistered(email.Value))
            {
                feedback.Value = "The entered email already exists as part of another account";
            }
            else
            {
                // check if the password matches confirm password
                if (password.Value == confPassword.Value)
                {
                    StudentClass s = new StudentClass
                    {
                        stuNum = stNum.Value,
                        name = name.Value,
                        surname = surname.Value,
                        email = email.Value,
                        contact = contact.Value,
                        password = password.Value,
                    };
                    bool Registration = client.RegisterStudent(s);

                    //check if operation was succesful and provide feedback
                    if (Registration)
                    {
                        feedback.Value = "You have succesfully been registered as a student";
                        stNum.Value = "";
                        name.Value = "";
                        surname.Value = "";
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