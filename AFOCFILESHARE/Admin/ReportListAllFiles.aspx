<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportListAllFiles.aspx.cs" Inherits="AFOCFILESHARE.Admin.ReportListAllFiles" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input[type=text]
        {
            width: 48% !important;
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
            height: 900px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <h3>
                List Files Details</h3>
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="col-md-6">
                            <form role="form">
                            <div class="form-group">
                                <label>
                                    From</label>
                                <asp:TextBox ID="txtFromdateListFiles" runat="server" ForeColor="Red" class="form-control-calender"
                                    placeholder="FromDate"></asp:TextBox>
                                <asp:Image ID="ImgUpload1" runat="server" ImageUrl="~/Styles/css-admin/calendar.png" />
                                <br />
                                <ajaxToolkit:CalendarExtender ID="calFromFile" runat="server" TargetControlID="txtFromdateListFiles"
                                    PopupButtonID="ImgUpload1">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtFromdateListFiles" runat="server"
                                    ErrorMessage="Please Select From Date" ForeColor="Red" ControlToValidate="txtFromdateListFiles"
                                    ValidationGroup="User"></asp:RequiredFieldValidator></div>
                             </form>
                   
                            <div class="form-group">
                                <label>
                                    To</label>
                                <asp:TextBox ID="txtTodateListFiles" runat="server" ForeColor="Red" class="form-control-calender"
                                    placeholder="To Date"></asp:TextBox>
                                <asp:Image ID="ImgUpload2" runat="server" ImageUrl="~/Styles/css-admin/calendar.png" />
                                <br />
                                <ajaxToolkit:CalendarExtender ID="calToFile" runat="server" TargetControlID="txtTodateListFiles"
                                    PopupButtonID="ImgUpload2">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtTodateListFiles" runat="server"
                                    ErrorMessage="Please Select To Date" ForeColor="Red" ControlToValidate="txtTodateListFiles"
                                    ValidationGroup="User"></asp:RequiredFieldValidator></div>
                        
                            <div class="form-group">
                                <label>
                                    File Name</label>
                               <asp:TextBox ID="txtFileName" runat="server" class="form-control-calender"  placeholder="FileName"></asp:TextBox>
                            </div>
                                                    
                            <asp:Button ID="btnShowReport" runat="server" class="btn btn-primary" Text="View Report"
                                ValidationGroup="User" onclick="btnShowReport_Click" />

                        </div>
                        <div>
                            
                            <rsweb:ReportViewer ID="rptListFiles" runat="server" Width="80%" Height="1000px">
                            </rsweb:ReportViewer>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col-->
        </div>
    </div>
</asp:Content>
