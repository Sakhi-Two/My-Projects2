<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditMerchant.aspx.cs" Inherits="AtEaseWeb.EditMerchant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div class="checkout__form">
                <h4>Edit Merchant Profile</h4>
                <form action="#">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="checkout__input">
                                <p>Name<span>*</span></p>
                                <input type="text" id="name" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Surname<span>*</span></p>
                                <input type="text" id="surname" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Contact<span>*</span></p>
                                <input type="text" id="contact" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Email<span>*</span></p>
                                <input type="text" id="mail" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Password<span>*</span></p>
                                <input type="password" id="password" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Confirm Password<span>*</span></p>
                                <input type="password" id="confPassword" runat="server">
                            </div>
                            <asp:Button type="submit" class="site-btn" text="CHANGE DETAILS" OnClick="btnEdit" runat="server"/>
                           <div visible="false" runat="server" id="themessageDiv">
                               <div class="col-md-12">
                                   <textarea name="message" id="feedback" cols="30" rows="5" placeholder="" runat="server"></textarea>
                               </div>
                           </div>
                        </div>
                    </div>
                </form>
            </div>
</asp:Content>
