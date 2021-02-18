<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="MerchantBoardMobile.aspx.cs" Inherits="AtEaseWeb.Mobile.MerchantBoardMobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
  width: 160px;
  background-color: white;
  color: black;
  text-align: center;
  border-radius: 6px;
  padding-top: 20px;
  padding-bottom: 20px;
  padding-right: 180px;
  padding-left: 100px;
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
  color: #9400D3;
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
    
     <!-- Merchant Dashboard -->
    <section class="shoping-cart spad">

        <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__btns">
                        <asp:Button class="site-btn" OnClick="btnSortDef_Click" Text="DEFAULT SORT" runat="server"/>
                        <asp:Button class="site-btn" OnClick="btnSortRate_Click" Text="RATING SORT" runat="server"/>
                        <asp:Button class="site-btn" OnClick="btnSortPrice_Click" Text="PRICE SORT" runat="server"/>
                        <input class="css-input" type="text" placeholder="By ISBN..." id="searchBar" runat="server">
                        <asp:Button type="submit" class="site-btn" OnClick="SearchBook" text="SEARCH TO EDIT" runat="server"/>
                   
                    </div>
                </div>
         </div>
        <hr/>
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__table">
                        <table>
                            <thead>
                                <tr>
                                    <th class="shoping__product">Book</th>
                                    <th>Name</th>
                                    <th>Rating</th>
                                    <th>Price</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody id="table" runat="server">

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>   
        </div>
        <div id="saveP" runat="server">
            
        </div>
    </section>
    <!-- Merchant Dashboard -->

        <script>
// When the user clicks on <div>, open the popup
function myFunction() {
  var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");

    var save = document.getElementById("mySave");
    save.classList.toggle("show");
            }

            function setPrice() {
                var thePrice = document.getElementById("newPrice");
            }
</script>
</asp:Content>
