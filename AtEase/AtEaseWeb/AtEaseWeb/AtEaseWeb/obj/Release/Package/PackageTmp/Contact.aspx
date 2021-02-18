<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AtEaseWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Find Us</h3>
    <!-- Map Section Begin -->
    <div class="map-section">
        <div class="container-fluid">
            <div class="row">
                <div class="map">
                   <iframe src="https://www.google.com/maps/embed?pb=!1m23!1m12!1m3!1d3580.4766257390534!2d27.994167451230894!3d-26.181169369315914!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m8!3e6!4m0!4m5!1s0x1e950b960c784d81%3A0x8166e2877ec6e9b2!2s5%20Kingsway%20Ave%2C%20Rossmore%2C%20Johannesburg%2C%202092!3m2!1d-26.181174199999997!2d27.9963615!5e0!3m2!1sen!2sza!4v1587449081359!5m2!1sen!2sza" width="1000" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
                </div>
            </div>
        </div>
    </div>
    <!-- Map Section End -->

    <address>
        <strong>Operating Week-Days:</strong>   <a>Monday – Friday: 9 am – 5 pm</a><br />
        <strong>Operating Weekends:</strong> <a>Saturday: 9 am – 1pm, closed on sundays.</a>
    </address>
</asp:Content>
