<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ExcelUpload.aspx.cs" Inherits="AFOCFILESHARE.Admin.ExcelUpload"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
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
                                <p class="help-block">
                                    Hi User, Please select the file you need to upload
                                    <br />
                                    please upload the folder file as zip format</p>
                                <label>
                                    File input</label>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <p class="help-block">
                                    Please select the File to Upload</p>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_FileUpload1" ForeColor="Red"
                                    runat="server" ControlToValidate="FileUpload1" ValidationGroup="check" ErrorMessage="File Required!"> </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="FileUpLoadValidator" runat="server" ForeColor="Red"
                                    ErrorMessage="Upload Excel only." ValidationExpression="^.*\.(xls|xlsx|csv|xlsm|xlsb|XLS|XLSX|CSV|XLSM|XLSB)$"
                                    ControlToValidate="FileUpload1" ValidationGroup="check">
                                </asp:RegularExpressionValidator>
                            </div>
                            <asp:Button ID="btnsubmit" runat="server" Text="Upload" class="btn btn-primary" OnClick="btnsubmit_Click1"
                                ValidationGroup="check" />
                           
                         </form>
                       <%-- <div class="col-md-6">--%>
                           <%-- <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="PageIndexChanging"
                                AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                            <br />
                            <asp:Button ID="btnExportPDF" runat="server" Text="ExportToPDF" OnClick="btnExportPDF_Click" />--%>
                       <%-- </div>--%>
                       
                       </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.col-->
    </div>
</asp:Content>
