<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AFOCFILESHARE.Users.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">	

   <div class="row" style="padding-top:20px; ">
            <div class="col-lg-12">
                <h2 class="page-header">
                    Dashboard</h2>
            </div>
        </div>
        <!--/.row-->
        <div class="row">
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-blue panel-widget ">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <svg class="glyph stroked upload"><use xlink:href="#stroked-upload"/></svg>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                           <a href="UploadFiles.aspx" style="text-decoration:none; color:Black;"> <div class="large">
                                <asp:Label ID="lblUpload" runat="server" Font-Size="30px"  Font-Bold="true" ></asp:Label></div>
                            <div class="text-muted">
                                Uploads</div></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-orange panel-widget">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <svg class="glyph stroked download"><use xlink:href="#stroked-download"/></svg>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                        <a href="ListFiles.aspx" style="text-decoration:none; color:Black;">
                            <div class="large">
                               <asp:Label ID="lblDownload" runat="server" Font-Size="30px" Font-Bold="true" ></asp:Label></div>
                            <div class="text-muted">
                                Downloads</div></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-teal panel-widget">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user"></use></svg>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                         <a href="#" style="text-decoration:none; color:Black;">
                            <div class="large">
                                 <asp:Label ID="lblUsers" runat="server" Font-Size="30px" Font-Bold="true" ></asp:Label></div>
                            <div class="text-muted">
                                Users</div></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-md-6 col-lg-3">
                <div class="panel panel-red panel-widget">
                    <div class="row no-padding">
                        <div class="col-sm-3 col-lg-5 widget-left">
                            <svg class="glyph stroked eye"><use xlink:href="#stroked-eye"/></svg>
                        </div>
                        <div class="col-sm-9 col-lg-7 widget-right">
                            <div class="large">
                                <a href="http://www.freecounterstat.com" title="web page counter">
                                    <img src="http://counter1.fcs.ovh/private/freecounterstat.php?c=4e651204fd3b05be6f7acbab439ce095"
                                        border="0" title="web page counter" alt="web page counter"></a></div>
                            <div class="text-muted">
                                Page Visit</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</div>
</asp:Content>
