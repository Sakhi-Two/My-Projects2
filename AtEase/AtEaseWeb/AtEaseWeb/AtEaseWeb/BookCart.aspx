<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookCart.aspx.cs" Inherits="AtEaseWeb.BookCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <style>
 /* Popup container */
.popup {
  position: relative;
  display: inline-block;
  cursor: pointer;
}

/* The actual popup (appears on top) */
.popup .popuptext {
  visibility: hidden;
  width: 260px;
  background-color: white;
  color: white;
  text-align: center;
  border-radius: 6px;
  padding: 50px 0px;
  position: absolute;
  z-index: 1;
  bottom: 125%;
  left: 50%;
  margin-left: -80px;
  border: 2px solid #9400D3;
}

/* Popup arrow */
.popup .popuptext::after {
  content: "";
  position: absolute;
  top: 100%;
  left: 50%;
  margin-left: -5px;
  border-width: 5px;
  border-style: solid;
  border: 2px solid #9400D3;
}

/* Toggle this class when clicking on the popup container (hide and show the popup) */
.popup .show {
  visibility: visible;
  -webkit-animation: fadeIn 1s;
  animation: fadeIn 1s
}

/* Add animation (fade in the popup) */
@-webkit-keyframes fadeIn {
  from {opacity: 0;}
  to {opacity: 1;}
}

@keyframes fadeIn {
  from {opacity: 0;}
  to {opacity:1 ;}
}
    </style>

    <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div>
                        <h2>My Books</h2>
                        <div class="breadcrumb__option">
                            <a href="Home.aspx">Home</a>
                            <span>Cart</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->

    <!-- Shoping Cart Section Begin -->
    <section class="shoping-cart spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__table">
                        <table>
                            <thead>
                                <tr>
                                    <th class="shoping__product">Books</th>
                                    <th>Merchant</th>
                                    <th>Price</th>
                                    <th>Remove</th>
                                </tr>
                            </thead>
                            <tbody id="table" runat="server">

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__btns">
                        <asp:Button class="site-btn" id="QouteD" OnClick="DownloadQuote" Text="DOWNLOAD QUOTATION" runat="server" Width="253px"/>
                    </div>
                    <br/>
                    <br/>
                    <div>   
                        
                        <div class='popup' onclick='myFunction()'>
                            <input type="submit" onclick="return false" value="CLEAR QUOTATION" class="site-btn" style="width:253px">
                            <span class='popuptext' id='myPopup'>
                                <asp:LinkButton ID="qC" 
                                        runat="server" 
                                         CssClass="btn btn-primary"    
                                         OnClick="ClearHome"
                                        BackColor="#a527db"
                                          Width="253px">
                                        <span aria-hidden="true" class="glyphicon glyphicon-home"></span>
                                </asp:LinkButton>
                                <h5 style="color:black">CLEAR AND EXIT</h5>
                                <br/>
                                <br/>
                                <asp:LinkButton ID="rC" 
                                        runat="server" 
                                         CssClass="btn btn-primary"    
                                         OnClick="ClearQuote"
                                        BackColor="#a527db"
                                          Width="253px">
                                        <span aria-hidden="true" class="glyphicon glyphicon-star"></span><span aria-hidden="true" class="glyphicon glyphicon-star"></span><span aria-hidden="true" class="glyphicon glyphicon-star"></span>
                                </asp:LinkButton>
                                <h5 style="color:black">RATE MERCHANTS</h5>
                                 </span>
                        </div>
                   </div>
                </div>
           
                <div class="col-lg-6" id="cartTotal" runat="server">
                    
                </div>
            </div>
            
        </div>
    </section>
    <!-- Shoping Cart Section End -->

    <script>
// When the user clicks on <div>, open the popup
function myFunction() {
  var popup = document.getElementById("myPopup");
  popup.classList.toggle("show");
}
</script>
</asp:Content>
