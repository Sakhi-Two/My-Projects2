<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AtEaseWeb.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html lang="zxx">



<body>
    
    <!-- Featured Section Begin -->
    <section class="featured spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title">
                        <h2>Featured Books</h2>
                    </div>
                </div>
            </div>
            <div class="row featured__filter" id="books" runat="server">
                
            </div>
        </div>
    </section>
    <!-- Featured Section End -->

    <!-- Latest Product Section Begin -->
    <section class="latest-product spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-4 col-md-6">
                    <div class="latest-product__text">
                        <h4>Latest Books</h4>
                        <div class="latest-product__slider owl-carousel" id="latest" runat="server">
                            
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="latest-product__text">
                        <h4>Top Searched Books</h4>
                        <div class="latest-product__slider owl-carousel" id="top" runat="server">
                          
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="latest-product__text">
                        <h4>Most Bought Books</h4>
                        <div class="latest-product__slider owl-carousel" id="mostBought" runat="server">
                            
                         
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Latest Product Section End -->

</body>

</html>
</asp:Content>
