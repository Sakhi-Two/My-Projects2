<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AtEaseWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
              <div class="checkout__form">
                <h4>Login</h4>
                <form action="#">
                    <div class="row">
                        <div class="col-lg-8 col-md-6" style="margin: auto">
                            <div class="checkout__input" style="text-align:center">
                                <p>Email<span>*</span></p>
                                <input type="text" id="email" runat="server" Width="1150px">
                            </div>
                            <div class="checkout__input" style="text-align:center">
                                <p>Password<span>*</span></p>
                                <input type="password" id="password" runat="server" Width="1150px">
                            </div>
                            <asp:Button class="site-btn" OnClick="LoginUser_Click" Text="Login" runat="server" Width="748px"/>
                        </div>

                        <div visible="false" runat="server" id="themessageDiv">
                    <div class="col-md-12">
                        <textarea name="message" id="feedback" cols="30" rows="5" placeholder="" runat="server"></textarea>
                    </div>
                   </div>
                  </div>
                </form>
            </div>
</asp:Content>
