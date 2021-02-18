<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="AtEaseWeb.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
 <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div>
                        <h2>Acquisition</h2>
                        <div class="breadcrumb__option">
                            <a href="Home.aspx">Home</a>
                            <span>Acquisition</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->

        <!-- Shoping Cart Section Begin -->
    <section class="shoping-cart spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__table">
                        <table>
                            <thead>
                                <tr>
                                    <th>Merchant</th>
                                    <th>Name</th>
                                    <th>Contact No.</th>
                                    <th>Email</th>
                                </tr>
                            </thead>
                            <tbody id="chats" runat="server">

                            </tbody>
                        </table>
                        
                    </div>
                </div>
            </div>
            <asp:Button class="site-btn" OnClick="GoToChat_Click" Text="CHAT WITH MERCHANTS" runat="server" Width="500px" />
        </div>
    </section>

    <!-- Checkout Section Begin -->
    <section class="checkout spad">
        <div class="container">
            
        </div>
    </section>
    <!-- Checkout Section End -->
</asp:Content>
