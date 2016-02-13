<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="NewUser.aspx.cs" Inherits="AFOCFILESHARE.Admin.NewUser" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">


        function passwordCompare(RePassword) {


            Password = $('#<%=txtPassword.ClientID%>').val();
            if (RePassword == Password) {
                updatePasswordBar(9);
            }
            else {
                Strength = document.getElementById('strendth');
                ErrorField = document.getElementById('passError');
                passwordStrength(Password, Strength, ErrorField);
            }
        }




        function passwordStrength(password, passwordStrength, errorField) {


            //password = password.trim();
            password = password.replace(/\s+/g, "");

            var score = 0;

            //if password bigger than 8 give another 1 point
            if (password.length >= 8) score++;

            //if password bigger than 12 give another 1 point
            if (password.length >= 12) score++;

            //if password has both lowercase and uppercase characters and numbers give 1 point 
            if ((password.match(/[a-z]/)) && (password.match(/[A-Z]/)) && (password.match(/\d+/))) score++;

            //if password has both numbers and lowercase and special characters give 1 point 
            if ((password.match(/\d+/)) && (password.match(/[a-z]/)) && (password.match(/.[!,@,#,$,%,^,&,*,?,_,~,-,(,)]/))) score++;

            //if password has both numbers and uppercase and special characters give 1 point 
            if ((password.match(/\d+/)) && (password.match(/[A-Z]/)) && (password.match(/.[!,@,#,$,%,^,&,*,?,_,~,-,(,)]/))) score++;

            //if password has both lowercase and uppercase and special characters give 1 point 
            if ((password.match(/[a-z]/)) && (password.match(/[A-Z]/)) && (password.match(/.[!,@,#,$,%,^,&,*,?,_,~,-,(,)]/))) score++;

            //if password lesser than 8 make 0 point
            if (password.length < 8) score = 0;

            updatePasswordBar(score);
        }



        function updatePasswordBar(rating) {

            var ratingMsgs = new Array(6);
            var ratingClasses = new Array(6);
            ratingMsgs[0] = "Too.Short";
            ratingMsgs[1] = "Weak";
            ratingMsgs[2] = "Strong";
            ratingMsgs[9] = "No Rated";
            ratingClasses[0] = 'short';
            ratingClasses[1] = 'weak';
            ratingClasses[2] = 'strong';
            ratingClasses[9] = 'notRated';

            var bar = document.getElementById('strength-bar');
            if (bar) {

                var message = document.getElementById('passwdRating');
                var barLength = document.getElementById('passwdBar').clientWidth;
                if (rating >= 0 && rating <= 2) {

                    bar.style.width = (barLength * (parseInt(rating) + 1.0) / 3.0) + 'px';
                    message.innerHTML = ratingMsgs[rating];

                } else if (rating > 2 && rating <= 8) {
                    rating = 2;
                    updatePasswordBar(rating);
                } else {
                    bar.style.width = 0;
                    rating = 9;
                    message.innerHTML = "";
                }
                message.className = ratingClasses[rating];
                bar.className = ratingClasses[rating];
            }
        }



    </script>
    <style type="text/css">
        .password-strengthcheck p
        {
            margin: 0 0 4px;
        }
        .password-strengthcheck .meter
        {
            height: 5px;
            background: #f5f5f5;
        }
        .password-strengthcheck .meter #strength-bar
        {
            display: block;
            height: 100%;
            width: 250px;
        }
        .password-strengthcheck .meter .short
        {
            background: #ff0000;
        }
        .password-strengthcheck .meter .weak
        {
            background: #2d98f3;
        }
        .password-strengthcheck .meter .strong
        {
            background: #76c261;
        }
        .password-strengthcheck .meter .notRated
        {
            background: #666;
        }
        
        
        
        .password-strengthcheck .msg #passwdRating
        {
            display: block;
        }
        .password-strengthcheck .msg .short
        {
            color: #ff0000;
        }
        .password-strengthcheck .msg .weak
        {
            color: #2d98f3;
        }
        .password-strengthcheck .msg .strong
        {
            color: #76c261;
        }
        .password-strengthcheck .msg .notRated
        {
            color: #ccc;
        }
    </style>
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">
                    Files Upload</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    
                    <div class="panel-body">
                        <div class="col-md-6">
                            <form role="form">
                            <div class="form-group">
                                <label>
                                    First Name</label>
                                <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="First Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtFirstName" runat="server"
                                    ErrorMessage="Enter First Name" ForeColor="Red" ControlToValidate="txtFirstName"
                                    ValidationGroup="Client"></asp:RequiredFieldValidator></div>
                            <div class="form-group">
                                <label>
                                    Last Name</label>
                                <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Last Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtLastName" runat="server"
                                    ForeColor="Red" ErrorMessage="Enter Last Name" ControlToValidate="txtLastName"
                                    ValidationGroup="Client"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>
                                    Email Address</label>
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email Address"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtEmail" runat="server" ErrorMessage="Email required"
                                    ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="Client"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="valEmailAdd" runat="server" ControlToValidate="txtEmail"
                                    ValidationGroup="Client" ValidationExpression=".*@.{2,}\..{2,}" ErrorMessage="Incorrect Email format."
                                    ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label>
                                    Retype Email</label>
                                <asp:TextBox ID="txtEmail_Retype" runat="server" class="form-control" placeholder="Retype Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtEmail_Retype" runat="server"
                                    ErrorMessage="Retype Email required" ForeColor="Red" ControlToValidate="txtEmail_Retype"
                                    ValidationGroup="Client"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator_txtEmail_Retype" runat="server"
                                    ControlToValidate="txtEmail_Retype" ValidationGroup="Client" ValidationExpression=".*@.{2,}\..{2,}"
                                    ErrorMessage="Incorrect Email format." ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator_Emails" runat="server" ErrorMessage="Emails Doesn't Match"
                                    ControlToCompare="txtEmail" ControlToValidate="txtEmail_Retype" ValidationGroup="Client"
                                    ForeColor="Red"></asp:CompareValidator>
                            </div>
                            </form>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>
                                    Desired Username</label>
                                <asp:TextBox ID="txtUsername" runat="server" placeholder=" Desired Username" class="form-control"
                                    onchange="CheckUsernameExistsByWSJQuery()" 
                                    onkeyup="BlockUsernameExistsByCode()" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtUsername" runat="server"
                                    ErrorMessage="Username Required" ForeColor="Red" ControlToValidate="txtUsername"
                                    ValidationGroup="Client"></asp:RequiredFieldValidator>
                                <div id="divUsernameExists" class="form-control" runat="server" style="display: none;
                                    float: right; color: #31a3c6; margin-left: 5px; text-align: center; font-weight: bold;
                                    font-variant: small-caps; font-size: medium;">
                                    <span style="color: Red">*</span> Username already exists
                                </div>
                                <div id="divUsernameError" runat="server" style="color: Red; 
                                    font-weight: bold; font-variant: small-caps; font-size: medium;"
                                    visible="false">
                                    <asp:Label ID="lblUsernameError" runat="server"></asp:Label></div>
                            </div>
                            <div class="form-group">
                                <label>
                                    Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" class="form-control"
                                    onkeyup="passwordStrength(this.value,document.getElementById('strendth'),document.getElementById('passError'))"></asp:TextBox>
                                <div class="hidden1" id="password-bar-html" role="alert">
                                    <div class="password-strengthcheck">
                                        <div class="msg">
                                            <span id="passwdRating"></span>
                                        </div>
                                        <div class="meter" id="passwdBar" class="form-control">
                                            <span id="strength-bar"></span>
                                        </div>
                                    </div>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtPassword"  runat="server"
                                    ErrorMessage="Password Required" ForeColor="Red" ControlToValidate="txtPassword"
                                    ValidationGroup="Client"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator_valPassword2" runat="server"
                                    ForeColor="Red" ControlToValidate="txtPassword" ValidationGroup="Client" ErrorMessage="Password must be atleast 8 characters."
                                    ValidationExpression="[^\s]{8,}" />
                            </div>
                            <div class="form-group">
                                <label>
                                    Retype Password</label>
                                <asp:TextBox ID="txtRePassword" runat="server"  placeholder="Retype Password" TextMode="Password" class="form-control"
                                    onkeyup="passwordCompare(this.value)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtRePassword" runat="server"
                                    ErrorMessage="Retype Password required" ForeColor="Red" ControlToValidate="txtRePassword"
                                    ValidationGroup="Client"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator_Passwords" runat="server" ErrorMessage="Passwords Doesn't Match"
                                    ForeColor="Red" ControlToCompare="txtPassword" ControlToValidate="txtRePassword"
                                    ValidationGroup="Client"></asp:CompareValidator>
                            </div>
                            <div class="form-group">
                                <label>
                                    User Privilage</label>
                                <asp:DropDownList ID="ddlPrivilage" runat="server" class="form-control">
                                    <asp:ListItem Selected="True">--Select Privilage--</asp:ListItem>
                                    <asp:ListItem Value="2">User</asp:ListItem>
                                    <asp:ListItem Value="1">Admin</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddlPrivilage" runat="server"
                                    ErrorMessage="Choose Privilage" InitialValue="--Select Privilage--" ForeColor="Red"
                                    ControlToValidate="ddlPrivilage" ValidationGroup="Client"></asp:RequiredFieldValidator>
                            </div>
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" 
                                ValidationGroup="Client" onclick="btnSubmit_Click1" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-default" 
                                onclick="btnCancel_Click1" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col-->
        </div>
    </div>
</asp:Content>
