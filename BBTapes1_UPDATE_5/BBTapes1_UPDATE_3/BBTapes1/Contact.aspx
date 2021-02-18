<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="BBTapes1.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Stylesheets -->
	<link rel="stylesheet" href="css/bootstrap.min.css"/>
	<link rel="stylesheet" href="css/font-awesome.min.css"/>
	<link rel="stylesheet" href="css/jquery-ui.min.css"/>
	<link rel="stylesheet" href="css/flaticon.css"/>
	<link rel="stylesheet" href="css/owl.carousel.css"/>
	<link rel="stylesheet" href="css/style.css"/>
	<link rel="stylesheet" href="css/animate.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navigation" runat="server">
    
	
	
	<!--  section -->
	<section class="page-info-section set-bg" data-setbg="img/page-info-bg.jpg">
		<div class="container">
			<div class="section-title text-center">
				<h2>Contact</h2>	
			</div>
		</div>
	</section>
	<!--  section end -->
	

	<!-- contact section -->
	<section class="contact-section">
		<div class="container">
			<div class="location-links">
				<p><span> South Africa </span></p>
				
			</div>
			<div class="contact-info">
				<p><span>A:</span> 08 Gloucester Str,Westdene,Johannesburg,1864</p>
				<p><span>T:</span> 011 565 4922</p>
				<p><span>E:</span> BBTapes@gmail.com</p>
			</div>
			<div>
			<img src="img\Location.jpg"/>
			<p><b> Coordinates : -26.1787848,27.9935056 </b></p>
			</div>
		
			<div class="section-title text-center">
				<h2>Contact Us</h2>	
			</div>
            <style>
                .fa {
                    padding: 20px;
                    font-size: 30px;  
                    width: 50px;
                    text-align: center;
                    color: yellow
                    }
                .fa:hover {
                            opacity: 0.1;
                            color: yellow;
                          }
            </style>
            <div class="text-center">
			    <a href="http://www.facebook.com/BBTapes-102961971124166/" class="fa fa-facebook"></a>
                <a href="http://instagram.com/bb_tapes" class="fa fa-instagram"></a>
            </div>
		</div>
	</section>
	<!--  contact section end -->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
	<!--====== Javascripts & Jquery ======-->
	<script src="js/jquery-3.2.1.min.js"></script>
	<script src="js/jquery-ui.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
	<script src="js/owl.carousel.min.js"></script>
	<script src="js/circle-progress.min.js"></script>
	<script src="js/main.js"></script>

</asp:Content>
