<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="AtEaseWeb.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="checkout__form">
                <h4>Register</h4>
                <form action="#">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="checkout__input">
                                <p>Student Number<span>*</span></p>
                                <input type="text" id="stNum" runat="server">
                            </div>
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
                                <input type="text" id="email" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Password<span>*</span></p>
                                <input type="password" id="password" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Confirm Password<span>*</span></p>
                                <input type="password" id="confPassword" runat="server">
                            </div>
                             <asp:Button type="submit" OnClick="RegStu" class="site-btn" text="REGISTER" runat="server"/>
                            <div class="checkout_input">
                                <textarea name="message" id="feedback" cols="30" rows="5"  placeholder="" runat="server"></textarea>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
</asp:Content>
