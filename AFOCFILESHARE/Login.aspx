<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AFOCFILESHARE.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html >
  <head>
 
    <meta charset="UTF-8">
    <title>AFOC - Armed Forces Officers Club & Hotel</title>
    
    
    <link rel="stylesheet" href="Scripts/Login/css/reset.css">

    <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
<link rel='stylesheet prefetch' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>

        <link rel="stylesheet" href="Scripts/Login/css/style.css">

      <!--B Validator-->
        <script type="text/javascript" src="Validator/jquery-1.11.0.min.js"></script>
        <script type="text/javascript" src="Validator/jquery.bvalidator.js"></script>
        <script type="text/javascript" src="Validator/jquery.bvalidator-yc.js"></script>
        <link href="Validator/bvalidator.css" rel="stylesheet" type="text/css" />

        <script type="text/javascript">
            $('#myform').bValidator();
        </script>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#myform').bValidator();
            });
</script>
    
    
  </head>

  <body>
   <style type="text/css">
  body
  {
      background: #ddd url(../LoginStyle/images/home111.jpg) repeat top left!important;
      }
      #btnlogin
      {
         background-color:#33b5e5!important;
      }
      
  </style>
    
<!-- Form Mixin-->
<!-- Input Mixin-->
<!-- Button Mixin-->
<!-- Pen Title-->
<div class="pen-title">
 <h1><strong style=" color:#082642; font-family:Arabic Transparent;">FILE SHARE PORTAL</strong> </h1>
				<h2 style=" color:White;  font-size:18px;">Hi User, Welcome to the webportal, Share your files on a single click...</h2>
</div>
<!-- Form Module-->
<div class="module form-module">
  <div >
    
  </div>
  <div class="form">
    <h2>Login to your account</h2>
    <form runat="server">
      <input type="text" id="txtUserName" name="login" runat="server" placeholder="Username" data-bvalidator="required" data-bvalidator-msg="Please Enter Username"/>
      <input type="password" id="txtPassword" name="password" runat="server" placeholder="Password" data-bvalidator="required" data-bvalidator-msg="Please Enter Password" />
      <%--<button>Login</button>--%>
      <asp:Button
        ID="btnlogin" runat="server" Text="Login" ForeColor="White" Font-Size="18px"  onclick="btnlogin_Click1" />
      <p id="err" runat="server" visible="false" style="color:Red;  font-size:medium; font-weight:bold" >
                    Incorrect Username/Password
                    
                    </p>
    </form>
  </div>
  <%--<div class="form">
    <h2>Create an account</h2>
    <form>
      <input type="text" placeholder="Username"/>
      <input type="password" placeholder="Password"/>
      <input type="email" placeholder="Email Address"/>
      <input type="tel" placeholder="Phone Number"/>
      <button>Register</button>
    </form>
  </div>--%>
  <%--<div class="cta"><a href="http://andytran.me">Forgot your password?</a></div>--%>
</div>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
<%--<script src='http://codepen.io/andytran/pen/vLmRVp.js'></script>
--%>
        <script src="Scripts/Login/js/index.js"></script>

    
    
    
  </body>
</html>