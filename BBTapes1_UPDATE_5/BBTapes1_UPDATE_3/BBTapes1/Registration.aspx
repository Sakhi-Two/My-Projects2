<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BBTapes1.Registration" %>
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
						Sign Up
					</span>

					<div class="wrap-input100 validate-input m-b-23" data-validate = "Username is required">
						<input class="input100" type="text" id="usrname" runat="server" name="username" placeholder="Username">
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 validate-input m-b-23" data-validate = "Email is required">
						<input class="input100" type="email" id="mail" runat="server" name="email" placeholder="Email">
						<span class="focus-input100"></span>
					</div>
					
                    <div class="wrap-input100 validate-input m-b-23" data-validate = "First name is required">
						<input class="input100" type="text" id="fName" runat="server" name="fname" placeholder="First Name">
						<span class="focus-input100"></span>
					</div>

                    <div class="wrap-input100 validate-input m-b-23" data-validate = "Last name is required">
						<input class="input100" type="text" id="lName" runat="server" name="lname" placeholder="Last Name">
						<span class="focus-input100"></span>
					</div>

                    <div class="wrap-input100 validate-input m-b-23" data-validate = "Contact number is required">
						<input class="input100" type="text" id="contact" runat="server" name="contact" placeholder="Contact Number">
						<span class="focus-input100"></span>
					</div>

                    <div class="wrap-input100 validate-input m-b-23" data-validate = "Address is required">
						<input class="input100" type="text" id="addres" runat="server" name="address" placeholder="Address">
						<span class="focus-input100"></span>
					</div>

                    <div class="wrap-input100 validate-input m-b-23" data-validate = "Password is required">
						<input class="input100" type="password" id="passw" runat="server" name="passw" placeholder="Password">
						<span class="focus-input100"></span>
					</div>

                    <div class="wrap-input100 validate-input m-b-23" data-validate = "Confirm password">
						<input class="input100" type="password" id="cpass" runat="server" name="cpass" placeholder="Confirm Password">
						<span class="focus-input100"></span>
					</div>
                   
                    <div class="wrap-input100 validate-input m-b-23" runat="server" id="UserType" visible="false">
                            <select class="form-control" id="theuserType" style="background-color:#212121;color:#ffe400;" runat="server">
                                <option selected>Customer</option>
                                <option value="1">Admin</option>
                                <option value="2">Manager</option>  
                            </select>                
                    </div>
                   
					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
							<asp:Button class="login100-form-btn" id="Register" Text="Sign Up" OnClick="btnReg_Click" runat="server"/>	
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
