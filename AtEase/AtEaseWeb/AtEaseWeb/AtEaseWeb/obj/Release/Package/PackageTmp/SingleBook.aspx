<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SingleBook.aspx.cs" Inherits="AtEaseWeb.SingleBook" %>
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
  width: 160px;
  background-color: #9400D3;
  color: #fff;
  text-align: center;
  border-radius: 6px;
  padding: 8px 0;
  position: absolute;
  z-index: 1;
  bottom: 125%;
  left: 50%;
  margin-left: -80px;
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
  border-color: #fff transparent transparent transparent;
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
    <!-- Product Details Section Begin -->
    <section class="product-details spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-6">
                    <div class="product__details__pic" id="book" runat="server">
                        
                       
                    </div>
                </div>
                <div class="col-lg-6 col-md-6" id="theBook" runat="server">
                   
                </div>
            
            </div>
        </div>

                     <div visible="false" runat="server" id="themessageDiv">
                    <div class="col-md-12">
                        <textarea name="message" id="feedback" cols="30" rows="5" placeholder="" runat="server"></textarea>
                    </div>
                   </div>

    </section>
    <!-- Product Details Section End -->

    <script>
// When the user clicks on <div>, open the popup
function myFunction() {
  var popup = document.getElementById("myPopup");
  popup.classList.toggle("show");
}
</script>

</asp:Content>
