<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="AtEaseWeb.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <!-- Shoping Cart Section Begin -->
    <section class="shoping-cart spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__table">
                        <table>
                            <thead>
                                <tr>
                                    <th class="shoping__product">Merchant</th>
                                    <th>Name</th>
                                    <th>Rating</th>
                                    <th>Review</th>
                                    <th>Report</th>
                                </tr>
                            </thead>
                            <tbody id="table" runat="server">

                            </tbody>
                        </table>

                        <asp:Button class="site-btn" id="SaveN" OnClick="SaveNext" Text="Save & Next" runat="server" Width="253px"/>
                        <asp:Button class="site-btn" id="Skip" OnClick="SkipR" Text="Skip Ratings" runat="server" Width="253px"/>
                    </div>
                </div>
                 <div visible="false" runat="server" id="themessageDiv">
                    <div class="col-md-12">
                        <textarea name="message" id="feedback" cols="30" rows="5" style="color:green;" placeholder="" runat="server"></textarea>
                    </div>
                </div>
            </div>
           </div>
        </section>
</asp:Content>
