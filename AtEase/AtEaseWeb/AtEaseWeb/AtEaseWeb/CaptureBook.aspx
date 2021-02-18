<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaptureBook.aspx.cs" Inherits="AtEaseWeb.CaptureBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           

             <div class="checkout__form">
                <h4>Add Book</h4>
                <form action="#">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="checkout__input">
                                <p>ENTER ISBN<span>*</span></p>
                                <input type="text" id="isbn" placeholder="13 digit ISBN" runat="server">
                            </div>
                            
                            <form action="/action_page.php">
                                <label for="img">Add Book Image:</label>
                                <input type="file" id="img" name="img" accept="image/*">
                            </form>

                            <button type="submit" class="site-btn">ADD BOOK TO STOCK</button>
                        </div>
                    </div>
                </form>
            </div>
</asp:Content>
