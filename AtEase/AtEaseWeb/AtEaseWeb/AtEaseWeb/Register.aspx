<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AtEaseWeb.Register1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="checkout__form">
                <h4>Register</h4>
                <form action="#">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="checkout__input">
                                <p>UserType<span>*</span></p>
                                <input type="text" list="users" id="usertype" runat="server">
                                <datalist id="users">
                                    <option value="Student">
                                    <option value="Merchant">
                                </datalist>
                            </div>
                            <asp:Button type="submit" text="Next" OnClick="pickUser" class="site-btn" runat="server"/>
                        </div>
                    </div>
                </form>
            </div>
</asp:Content>
