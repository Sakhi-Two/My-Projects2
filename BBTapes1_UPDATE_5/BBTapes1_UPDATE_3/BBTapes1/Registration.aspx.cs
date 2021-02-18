using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BBTapes1.MyServiceReference;
using BBTapeService;
namespace BBTapes1
{
    public partial class Registration : System.Web.UI.Page
    {
        BBTapesServiceClient client = new BBTapesServiceClient();
        String UserType = "Customer";
        protected void Page_Load(object sender, EventArgs e)
        {
            var select=0;
            if (Session["UserType"] != null)
            {

                if (Session["UserType"].ToString() == "Manager")
                {

                    theuserType.Visible = true;
                   
                    if (!IsPostBack)
                    {
                        select = theuserType.SelectedIndex;
                        if (select.Equals(1))
                        {
                            UserType = "Customer";
                        }
                        else if (select.Equals(2))
                        {
                            UserType = "Admin";
                        }
                        else
                        {
                            UserType = "Manager";
                        }
                    }
                }
            }

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            
              if (passw.Value.Equals(cpass.Value))
              {
                var isReg = client.Registered(usrname.Value, passw.Value);

               
                if (isReg.Equals(false))
                {
                    
                    UsersInfo user = new UsersInfo
                    {
                        name = fName.Value,
                        surname = lName.Value,
                        username = usrname.Value,
                        email =mail.Value,
                        address = addres.Value,
                        contacts=contact.Value,
                        password = passw.Value,
                        UserType = UserType

                    };
                    int register = client.Register(user);
                   // Console.WriteLine(register);
                    if (register.Equals(1))
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        themessage.InnerText = "Registration unsucessfull";
                        themessageDiv.Visible = true;

                    }
                }
                else
                {
                    themessage.InnerText = "Username and password already exist";
                    themessageDiv.Visible = true;
                }

            }
            else
            {
                themessage.InnerText = "Incorrect password";
                themessageDiv.Visible = true;
            }

            
     
        }
    }
}