<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="AtEaseWeb.Reviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
* {
        margin: 0px;
        padding: 0px;
}
.box3 {
  width: 300px;
  margin: 50px auto;
  border-radius: 15px;
  background: #00bfb6;
  color: #fff;
  padding: 20px;
  text-align: center;
  font-weight: 900;
  font-family: arial;
  position: relative;
}


/* speech bubble 13 */

.sb13:before {
  content: "";
  width: 0px;
  height: 0px;
  position: absolute;
  border-left: 15px solid #00bfb6;
  border-right: 15px solid transparent;
  border-top: 15px solid #00bfb6;
  border-bottom: 15px solid transparent;
  right: -16px;
  top: 0px;
}


/* speech bubble 14 */

.sb14:before {
  content: "";
  width: 0px;
  height: 0px;
  position: absolute;
  border-left: 15px solid transparent;
  border-right: 15px solid #00bfb6;
  border-top: 15px solid #00bfb6;
  border-bottom: 15px solid transparent;
  left: -16px;
  top: 0px;
}




    .column {
  float: right;
}
    .left, .right {
  width: 25%;
}

.middle {
  width: 50%;
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}
    </style>
    <!-- Featured Section Begin -->
    <section class="featured spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title">
                        <h2>Reviews</h2>
                    </div>
                </div>
            </div>
            <div class="row featured__filter" id="feedback" runat="server">
                
            </div>
        </div>
    </section>
    <!-- Featured Section End -->
</asp:Content>
