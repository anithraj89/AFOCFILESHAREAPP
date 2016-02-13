<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="UploadFiles.aspx.cs" Inherits="AFOCFILESHARE.Admin.UploadFiles" %>

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
                                <%--<input type="file" id="xxxx" runat="server" />--%>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <p class="help-block">
                                    Please select the File to Upload</p>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_FileUpload1" ForeColor="Red"
                                    runat="server" ControlToValidate="FileUpload1" ValidationGroup="check" ErrorMessage="File Required!"> </asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="FileUpLoadValidator" runat="server" ForeColor="Red" ErrorMessage="Upload Excel only."
                                    ValidationExpression="^.*\.(xls|xlsx|csv|xlsm|xlsb|XLS|XLSX|CSV|XLSM|XLSB)$" ControlToValidate="FileUpload1" ValidationGroup="check">
                                </asp:RegularExpressionValidator>
                                
                            </div>

                           

                                  <asp:Button ID="btnsubmit" runat="server" Text="Upload" class="btn btn-primary" OnClick="btnsubmit_Click1"
                            ValidationGroup="check" />

                             </form>
                        </div>
                      
                       
                    </div>
                </div>
            </div>
        </div>
        <!-- /.col-->
    </div>

</asp:Content>
