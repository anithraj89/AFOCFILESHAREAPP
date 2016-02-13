<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="AFOCFILESHARE.Admin.AdminHome" %>
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
                         <a href="NewUser.aspx" style="text-decoration:none; color:Black;">
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
                                <a  title="web page counter">
                                    <img src="http://counter1.fcs.ovh/private/freecounterstat.php?c=4e651204fd3b05be6f7acbab439ce095"
                                        border="0" title="web page counter" alt="web page counter"></a></div>
                            <div class="text-muted">
                                Page Visit</div>
                        </div>
                    </div>
                </div>
            </div>



            
        </div>




        <div class="panel panel">
     <div class="panel-body">
		<p>Ever since its opening, the prestigious Armed Forces Officers Club and Hotel continues to intrigue and enthrall its guests.With its internationally acclaimed architectural design and unmatched Arabic hospitality the luxurious 5-star has come to establish itself as unique hotel in the modern urban landscape of the United Arab Emirates.
</p>

<p>All its 600 elegantly appointed guest rooms and luxurious suites are embraced by an impressive, inner garden, which is one of the world’s largest assemblies of 142 species of plants in an indoor location. Not surprisingly, the hotel was honoured with the prestigious British Association of Landscape Industries “BALI” Landscape Award in 2002.
</p>
<p>Relax in your room and watch your favorite movie on the LCD television. If you require extra workspace our business centre is complete with all modern facilities and equipment. When it’s time to put your workday aside, relax and rejuvenate in our health club which boasts extensive, world-class sports and leisure facilities. During a vacation, nothing is better than indulging in great food. We have more than eight restaurants and lounges serving diverse cuisines ranging from ambient lounges to European fine dining.</p>

<p>If you are looking to host a meeting or celebration, our gracious banquet halls are perfect for such occasions. We are pleased to greet you in our Grand Theatre seating up to 700 pax or our Cinema seating up to 200 px.
We look forward to welcoming you and your guests at the Armed Forces Officers Club and Hotel where Arabian Hospitality is at its best.</p></div>
</div>
</div>
</asp:Content>
