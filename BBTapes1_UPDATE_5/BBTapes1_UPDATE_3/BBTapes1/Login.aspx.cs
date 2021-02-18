using BBTapes1.MyServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BBTapeService;

namespace BBTapes1
{
    
    public partial class Login : System.Web.UI.Page
    {
        BBTapesServiceClient client = new BBTapesServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
             int userLogin = client.Login(username.Value, password.Value);
              UsersInfo user = client.getUsers(username.Value);
              if (userLogin !=0 )
              {
                  Session["Username"] = username.Value;
                  Session["UserType"] = user.UserType; 
                  Response.Redirect("Home.aspx");
              }
        }
    }
}