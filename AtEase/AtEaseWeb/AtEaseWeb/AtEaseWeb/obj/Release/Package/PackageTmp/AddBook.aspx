<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="AtEaseWeb.AddBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            
         <div class="checkout__form">
                <h4>Add Book</h4>
                <form action="#">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="checkout__input">
                                <p>ISBN<span>*</span></p>
                                <input type="text" id="isbn" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Book Name<span>*</span></p>
                                <input type="text" id="bName" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Author<span>*</span></p>
                                <input type="text" id="bAuthor" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Edition<span>*</span></p>
                                <input type="text" id="bEdition" runat="server">
                            </div>
                            <button type="submit" class="site-btn">ADD BOOK</button>
                        </div>
                    </div>
                </form>
            </div>
</asp:Content>
