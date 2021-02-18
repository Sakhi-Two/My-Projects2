<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="AtEaseWeb.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   

    <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div>
                        <h2>Search Results</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->

    <!-- Product Section Begin -->
    <section>
            <div class="row">
                <div class="col">
                        <hr>
                        <div class="row" style="margin: auto; overflow:visible;" id="mainBook" runat="server">
                               
                                   
                                
                                
                        </div>
                        <hr>
                            <section class="related-product">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="section-title related__product__title">
                                                <h2>Merchants</h2>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        <div class="row" style="margin: auto;" id="product" runat="server">
                               
                                   
                                
                                
                        </div>
                </div>
            </div>

    </section>
    <!-- Product Section End -->
</asp:Content>
