<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="AtEaseWeb.EditStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       
         <div class="checkout__form">
                <h4>Edit Student Profile</h4>
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
                                <p>Degree<span>*</span></p>
                                <input type="text" id="degree" runat="server">
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

                            <button type="submit" class="site-btn">CHANGE DETAILS</button>
                        </div>
                    </div>
                </form>
            </div>
</asp:Content>
