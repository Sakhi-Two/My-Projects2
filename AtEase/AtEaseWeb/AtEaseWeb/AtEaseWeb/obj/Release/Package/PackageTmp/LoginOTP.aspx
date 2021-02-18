<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginOTP.aspx.cs" Inherits="AtEaseWeb.LoginOTP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


         <div class="checkout__form">
                <h4>Login OTP</h4>
                <form action="#">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="checkout__input">
                                <p>OTP<span>*</span></p>
                                <input type="text" id="otp" placeholder="Enter OTP" runat="server">
                            </div>
                            <button type="submit" class="site-btn">SUBMIT</button>
                        </div>
                    </div>
                </form>
            </div>
</asp:Content>
