using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BBTapes1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public int quantity;

        protected void Page_Load(object sender, EventArgs e)
        {
            string display = "";
            string url = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

            if (url == "Home.aspx")
            {
                display += "<li class='active' id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='dropdown' id='item_Catalogue'>";
                display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li id ='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";
                

                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                    
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='dropdown' id='UserM' runat='server'>";
                            display += "<a href='#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href='EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href='AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href='DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li id='Cart2' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>"+quantity+"</span></i></a></li>";
                   
                    //Login.Visible = false;
                    //Logout.Visible = true;
                    
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";      
                }
            }
            else if (url == "Contact.aspx")
            {
                display += "<li id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='dropdown' id='item_Catalogue'>";
                display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li class='active' id='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";


                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                  
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='dropdown' id='UserM' runat='server'>";
                            display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href = 'EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li id='Cart2' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>" + quantity + "</span></i></a></li>";

                    //Login.Visible = false;
                    //Logout.Visible = true;
                    
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";
                }
            }
            else if(url == "About.aspx")
            {
                display += "<li id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='dropdown' id='item_Catalogue'>";
                display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li id ='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li class='active' id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";

                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='dropdown' id='UserM' runat='server'>";
                            display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href = 'EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li id='Cart2' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>" + quantity + "</span></i></a></li>";

                    //Login.Visible = false;
                    //Logout.Visible = true;
                   
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";
                }
            }
            else if (url == "AboutProduct.aspx")
            {
                display += "<li id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='active' id='item_Catalogue'>";
                display += "<a href='#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li id ='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";


                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                   
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='dropdown' id='UserM' runat='server'>";
                            display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href = 'EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li id='Cart2' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>" + quantity + "</span></i></a></li>";

                    //Login.Visible = false;
                    //Logout.Visible = true;
                    
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";
                }
            }
            else if(url == "Catalogue.aspx")
            {
                display += "<li id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='active' id='item_Catalogue'>";
                display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li id ='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";


                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                   
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='dropdown' id='UserM' runat='server'>";
                            display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href = 'EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li id='Cart2' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>0</span></i></a></li>";

                    //Login.Visible = false;
                    //Logout.Visible = true;
                 
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";
                }
            }
            else if (url == "AddAlbum.aspx" || url == "EditAlbum.aspx" || url == "DeleteAlbum.aspx")
            {
                display += "<li id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='dropdown' id='item_Catalogue'>";
                display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li id ='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";


                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                   
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='active' id='UserM' runat='server'>";
                            display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href = 'EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li id='Cart2' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>0</span></i></a></li>";

                    //Login.Visible = false;
                    //Logout.Visible = true;
                    
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";
                }
            }
            else if (url == "Checkout.aspx")
            {
                display += "<li id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='dropdown' id='item_Catalogue'>";
                display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li id ='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";


                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                   
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='dropdown' id='UserM' runat='server'>";
                            display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href = 'EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li id='Cart2' class='active' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>0</span></i></a></li>";

                    //Login.Visible = false;
                    //Logout.Visible = true;
                 
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";
                }
            }
            else if (url == "Login.aspx")
            {
                display += "<li id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='dropdown' id='item_Catalogue'>";
                display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li id ='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";


                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li class='active' id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                  
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='dropdown' id='UserM' runat='server'>";
                            display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href = 'EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href = 'DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li id='Cart2' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>0</span></i></a></li>";

                    //Login.Visible = false;
                    //Logout.Visible = true;
                  
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";
                }
            }
            else if (url == "Registration.aspx")
            {
                display += "<li id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='dropdown' id='item_Catalogue'>";
                display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li id ='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li class='active' id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";


                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                   
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='dropdown' id='UserM' runat='server'>";
                            display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href='EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href='AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href='DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li id='Cart2' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>0</span></i></a></li>";

                    //Login.Visible = false;
                    //Logout.Visible = true;
                    
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";
                }
            }
            else if (url == "ShoppingCart.aspx")
            {
                display += "<li id='Home'><a href='Home.aspx'> Home </a></li>";
                display += "<li class='dropdown' id='item_Catalogue'>";
                display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>Catalogue</a>";
                display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=2' style='background-color: #212121'>New School</a></li>";
                display += "<li class='dropdown-item-text'><a href ='Catalogue.aspx?ArtistType=1' style='background-color: #212121'>Old School</a></li>";
                display += "</ul>";
                display += "</ li >";
                display += "<li id ='item_Contact'><a href='Contact.aspx'>Contact</a></li>";
                display += "<li id='item_About'><a href='About.aspx'>About</a></li>";
                display += "<li id='item_SingUp' runat='server'><a href='Registration.aspx'>Sign up</a></li>";


                if (Session["Username"] == null)
                {
                    // Cart2.Visible = false;
                    // Logout.Visible = false;
                    // UserM.Visible = false;
                    display += "<li id='Login' runat='server'><a href='Login.aspx'>Login</a></li>";
                   
                }
                else
                {
                    if (Session["UserType"] != null)
                    {
                        if (Session["UserType"].Equals("Manager"))
                        {
                            //  UserM.Visible = true;
                            display += "<li class='dropdown' id='UserM' runat='server'>";
                            display += "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>User Management</a>";
                            display += "<ul class='dropdown-menu' style='background-color: #212121'>";
                            display += "<li class='dropdown-item-text'><a href='EditAlbum.aspx' style='background-color: #212121'>Edit Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href='AddAlbum.aspx' style='background-color: #212121'>Add Album</a></li>";
                            display += "<li class='dropdown-item-text'><a href='DeleteAlbum.aspx' style='background-color: #212121'>Delete Album</a></li>";
                            display += "</ul>";
                            display += "</li>";
                        }
                    }

                    //Cart2.Visible = true;
                    display += "<li class='active' id='Cart2' runat='server'><a href='ShoppingCart.aspx'><i class='glyphicon glyphicon-shopping-cart' id='Cart' runat='server' visible='true'><span class='badge badge-secondary badge-pill' style='background-color:#ffe400;color:black'>0</span></i></a></li>";

                    //Login.Visible = false;
                    //Logout.Visible = true;
                   
                        display += "<li id='Logout' runat='server'><a href='Logout.aspx'>Logout</a></li>";
                }
            }
            menu.InnerHtml = display; 
        }
    }
}