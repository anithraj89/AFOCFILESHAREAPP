<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReportUploadDetails.aspx.cs" Inherits="AFOCFILESHARE.Admin.ReportUploadDetails" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style type="text/css">
        input[type=text]
        {
            width: 45% !important;
        }
        select
        {
            width: 45% !important;
        }
        label
        {
            width: 18% !important;
        }
        body
        {
            height:900px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
    <div class="row">
         <h3 >
                    Upload Files</h3>
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="col-md-6">
                            <form role="form">
                            <div class="form-group">
                                <label>
                                    From</label>
                                <asp:TextBox ID="txtFromdateUpload" runat="server" ForeColor="Red" class="form-control-calender"
                                    placeholder="FromDate"></asp:TextBox>
                                <asp:Image ID="ImgUpload1" runat="server" ImageUrl="~/Styles/css-admin/calendar.png" />
                                <br />
                                <ajaxToolkit:CalendarExtender ID="calupload1" runat="server" TargetControlID="txtFromdateUpload"
                                    PopupButtonID="ImgUpload1">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtFromdateUpload" runat="server"
                                    ErrorMessage="Please Select From Date" ForeColor="Red" ControlToValidate="txtFromdateUpload"
                                    ValidationGroup="User"></asp:RequiredFieldValidator></div>
                            
                    </form>
                            <div class="form-group">
                                <label>
                                    To</label>
                                <asp:TextBox ID="txtTodateUpload" runat="server" ForeColor="Red" class="form-control-calender"
                                    placeholder="To Date"></asp:TextBox>
                                <asp:Image ID="ImgUpload2" runat="server" ImageUrl="~/Styles/css-admin/calendar.png" />
                                <br />
                                <ajaxToolkit:CalendarExtender ID="calupload2" runat="server" TargetControlID="txtTodateUpload"
                                    PopupButtonID="ImgUpload2">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtTodateUpload" runat="server"
                                    ErrorMessage="Please Select To Date" ForeColor="Red" ControlToValidate="txtTodateUpload"
                                    ValidationGroup="User"></asp:RequiredFieldValidator></div>
                           
                     
                               
                                <div class="form-group">
                                    <label>
                                        User</label>
                                    <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="SqlDataSource1" DataTextField="User_Name"
                                        DataValueField="User_Name" class="form-control-calender" AppendDataBoundItems="true">
                                        <asp:ListItem Text="All" Value="all" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                               
                                                        
                              
                                <asp:Button ID="btnShowReport" runat="server" class="btn btn-primary" Text="View Report"
                                    ValidationGroup="User" OnClick="btnShowReport_Click"  />
                               
                        </div>
                        <div>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FILESHAREConnectionString %>"
                                SelectCommand="SELECT [User_Name] FROM [Users]"></asp:SqlDataSource>
                            <rsweb:ReportViewer ID="rptListUpload" runat="server" Width="80%" Height="1000px">
                            </rsweb:ReportViewer>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col-->
        </div>
    </div>
</asp:Content>
