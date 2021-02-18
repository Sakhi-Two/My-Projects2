 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BBTapes1.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navigation" runat="server">
                                                
	<                                              
	<!-- Hero section -->
	<section class="hero-section set-bg" data-setbg="img/bg.jpeg">
		<div class="hero-slider owl-carousel">
			<div class="hs-item">
				<div class="container">
					<a href="Registration.aspx"><h1>Sign Up</h1></a>
					<h3><font color="yellow">To get get all your physical copies of boom bap music in one place. <br>Whether new or old school, we got you!</font></h3>
				</div>
			</div>
				
			<div>
				<div class="hero-slider owl-carousel">
					<div class="hs-item">
						<div class="container">
							<h3><font color="yellow">Play our royalty free instrumentals<br> as you browse our timeless catalog of albums.</font></h3>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- Hero section end -->


	<!-- promotion section -->
	<section class="category section">
		<div class="container">
			<div class="row">
				<div class="col-md-6">
                    <a href="Catalogue.aspx?ArtistType=2">
					    <div class="promo-box set-bg" data-setbg="img/promo/1.jpg">
						    <h2>New School</h2>
					    </div>
                    </a>
				</div>
				<div class="col-md-6">
                    <a href="Catalogue.aspx?ArtistType=1">
					    <div class="promo-box set-bg" data-setbg="img/promo/2.jpg">
						    <h2>Old School</h2>
					    </div>
                    </a>
				</div>
			</div>
		</div>
	</section>
	<!-- promotion section end -->


	<!-- Latest Podcast section -->
	<section class="latest-podcast-section spad">
		<div class="container">
			<div class="section-title text-center">
				<h2>What's Hot Right Now</h2>	
			</div>
			<div class="new-project-player">
				<div class="row">
					<div class="col-lg-4 albam-preview">
						<img src="img/Aesop Rock Impossible Kid.jpg" alt="">
					</div>
					<div>
						<h3>Aesop Rock - Impossible Kid</h3>
						<h5><br><br>
                            The Impossible Kid is the seventh studio album by American <br>hip hop artist Aesop Rock. It was released on 
                            <br>April 29, 2016 through Rhymesayers Entertainment. 
                            <br>The production is handled by Aesop Rock himself. <br>The cover art is created by Alex Pardee.
                            <br><br>
                            While creating the album, Aesop Rock spent a year in his friend's <br> barn in order to escape his 
						   troubles and lingering depression.<br> He sold all his possessions, bringing <br> along only a bag of clothes and his cat, Kirby.
						</h5>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- Latest Podcast section end -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
