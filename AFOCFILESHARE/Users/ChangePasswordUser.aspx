<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="ChangePasswordUser.aspx.cs" Inherits="AFOCFILESHARE.Users.ChangePasswordUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">


        function passwordCompare(RePassword) {


            Password = $('#<%=txtRePassword.ClientID%>').val();
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">
                  Change  Password</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                    <div class="col-md-6">
                            <div class="form-group">
                                <label>
                                    Current Password</label>
                                <asp:TextBox ID="txtCurrentPassword" runat="server" placeholder="Current Password" class="form-control"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtCurrentPassword" runat="server" ErrorMessage="Enter Current Password" ForeColor="Red" 
            ControlToValidate="txtCurrentPassword" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
            
          
                            </div>
                            <div class="form-group">
                                <label>
                                    New Password</label>
                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="New Password" class="form-control"
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
                                    ErrorMessage="Password Required" ForeColor="Red" ControlToValidate="txtNewPassword"
                                    ValidationGroup="Client"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator_valnewPassword" runat="server"
                                    ForeColor="Red" ControlToValidate="txtNewPassword" ValidationGroup="Client" ErrorMessage="Password must be atleast 8 characters."
                                    ValidationExpression="[^\s]{8,}" />
                            </div>
                            <div class="form-group">
                                <label>
                                    Retype New Password</label>
                                <asp:TextBox ID="txtRePassword" runat="server"  placeholder="Retype New Password" TextMode="Password" class="form-control"
                                    onkeyup="passwordCompare(this.value)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtRePassword" runat="server"
                                    ErrorMessage="Retype Password required" ForeColor="Red" ControlToValidate="txtRePassword"
                                    ValidationGroup="Client"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator_Passwords" runat="server" ErrorMessage="Passwords Doesn't Match"
                                    ForeColor="Red" ControlToCompare="txtNewPassword" ControlToValidate="txtRePassword"
                                    ValidationGroup="Client"></asp:CompareValidator>
                            </div>
                            
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" 
                                ValidationGroup="Client" onclick="btnSubmit_Click1" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-default" 
                                onclick="btnCancel_Click1" />
                                <div id="divLoginError" runat="server" class="form-control" style="color:Red; text-align:left;" Visible="false"><asp:Label ID="lblLoginError" runat="server"></asp:Label></div>
                                <div id="divLoginSuccess" runat="server" class="form-control" style="color:Green; text-align:left;" Visible="false"><asp:Label ID="lblLoginSuccess" runat="server"></asp:Label></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
