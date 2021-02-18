<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerBoard.aspx.cs" Inherits="AtEaseWeb.ManagerBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">     
    <!-- Manager Dashboard -->
    <section class="shoping-cart spad">
        <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__btns">
                         
                        <asp:Button class="site-btn" OnClick="DefSort_Click" Text="DEFAULT SORT" runat="server"/>
                        <asp:Button class="site-btn" OnClick="btnSortStrikes_Click" Text="STRIKES SORT" runat="server"/>
                    </div>
                </div>
         </div>
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__table">
                        <table>
                            <thead>
                                <tr>
                                    <th class="shoping__product">Merchant</th>
                                    <th>Merchant Rating</th>
                                    <th>Merchant Reviews</th>
                                    <th>Strikes</th>
                                    <th>Remove</th>
                                </tr>
                            </thead>
                            <tbody id="table" runat="server">

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>   
        </div>
    </section>
    <!-- Manager Dashboard -->
</asp:Content>
