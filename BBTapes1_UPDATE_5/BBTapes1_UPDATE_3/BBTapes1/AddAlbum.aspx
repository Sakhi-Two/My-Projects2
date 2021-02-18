<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddAlbum.aspx.cs" Inherits="BBTapes1.AddAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="logincss/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="logincss/util.css">
	<link rel="stylesheet" type="text/css" href="logincss/main.css">
<!--===============================================================================================-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navigation" runat="server">
    <div class="limiter">
		<div class="container-login100" style="background-image: url('img/headVBG.jpg');">
			<div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-54">
				<form class="login100-form validate-form">
					<span class="login100-form-title p-b-49">
						Add Album
					</span>

					<div class="wrap-input100 validate-input m-b-23" data-validate = "Artist ID is required">
						<input class="input100" type="text" id="arID" runat="server" name="artistid" placeholder="Artist ID">
						<span class="focus-input100"></span>
					</div>
					
                    <div class="wrap-input100 validate-input m-b-23" data-validate = "Album name is required">
						<input class="input100" type="text" id="aName" runat="server" name="albumname" placeholder="Album Name">
						<span class="focus-input100"></span>
					</div>

                    <div class="wrap-input100 validate-input m-b-23" data-validate = "Price is required">
						<input class="input100" type="text" id="aPrice" runat="server" name="price" placeholder="Price">
						<span class="focus-input100"></span>
					</div>

                    <div class="wrap-input100 validate-input m-b-23" data-validate = "Release Date is required">
						<input class="input100" type="text" id="rDate" runat="server" name="releasedate" placeholder="Release Date">
						<span class="focus-input100"></span>
					</div>

                    <div class="wrap-input100 validate-input m-b-23" data-validate = "Album Image is required">
						<input class="input100" type="text" id="img" runat="server" name="image" placeholder="Album Image">
						<span class="focus-input100"></span>
					</div>

                   
					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
							<asp:Button class="login100-form-btn" id="Add" Text="Add Album" OnClick="btnAdd_Click" runat="server"/>	
						</div>
					</div>

                    <div class="row form-group" visible="false" runat="server" id="themessageDiv">
                    <div class="col-md-12">
                        <textarea name="message" id="themessage" cols="30" rows="5" class="form-control" placeholder="" runat="server"></textarea>
                    </div>
                </div>

				</form>
			</div>
		</div>
	</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
