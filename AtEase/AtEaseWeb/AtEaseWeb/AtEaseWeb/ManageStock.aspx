<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageStock.aspx.cs" Inherits="AtEaseWeb.ManageStock" %>
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
               <div class="checkout__form">
                <h4>Manage Stock</h4>

                <form action="#">
                    <div class="row">
                        
                        <div class="col-lg-8 col-md-6" style="margin: auto">
                            <!--Image UPLOAD -->
                        <div class="col-lg-8 col-md-6 offset-3 mx-auto" style="margin: auto">
                            <div class="custom_file_upload">
                                <div class="file_upload">
                                    <p style="color:white">UPLOAD TEXTBOOK</p>
                                    <asp:FileUpload ID="theImage" runat="server" Width="211px" Text="File"/>
                                    <asp:Label ID="lblImg" runat="server"></asp:Label>
                                </div>
                            </div>
                         </div>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <!--ISBN INPUT -->
                            <div class="checkout__input" style="text-align:center">
                                <p>ISBN<span>*</span></p>
                                <input type="text" id="isbn" name="isbn" runat="server" Width="1150px">
                            </div>
                            <!--Price INPUT -->
                            <div class="checkout__input" style="text-align:center">
                                <p>Price<span>*</span></p>
                                <input type="text" name="theprice" id="theprice" runat="server" Width="1150px">
                            </div>
                            <!--ADD BUTTON -->
                           <asp:Button ID="btnConfirm" class="site-btn" OnClick="AddBook_Click" Text="ADD BOOK" runat="server"/>
                            <div id="mypop" runat="server">

                            </div>
                        </div>

                            <div visible="false" runat="server" id="themessageDiv">
                               <div class="col-md-12">
                                   <textarea name="message" id="feedback" cols="30" rows="5" placeholder="" runat="server"></textarea>
                               </div>
                           </div>
                  </div>
                </form>
            </div>

    <script>
// When the user clicks on <div>, open the popup
function myFunction() {
  var popup = document.getElementById("myPopup");
  popup.classList.toggle("show");
}
</script>

</asp:Content>
