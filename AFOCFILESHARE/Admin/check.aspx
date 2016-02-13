<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check.aspx.cs" Inherits="AFOCFILESHARE.Admin.check" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
    local SERVER = '<SMTP SERVER>';
    local USERNAME = '<SMTP USERNAME>';
    local PASSWORD = '<SMTP PASSWORD>';
 
        email.send {
	        server=SERVER, username=USERNAME, password=PASSWORD,
	        from='hello@webscript.io',
	        to=request.form.email,
	        subject='Webscript demo: file attachment',
	        text='This is an automated email from a Webscript example. '..
		        '(https://www.webscript.io/script/examples/attachments/file)',
	        attachments = { request.files.attachment }
                    }
                return "Email sent."
                
                </script>
</head>
<body>
    <%-- <form id="form1" runat="server">
    <div>
        To <b>Admin</b> <br>
        From <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
        <br />
        Subject <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
        <br />
        Message <asp:TextBox ID="txtBody" runat="server" Height="70px" TextMode="MultiLine"
            Width="190px"></asp:TextBox>  <br />
        Attachment <asp:FileUpload ID="fuAttachment" runat="server" />
        <br />
        <asp:Button ID="btnSend" runat="server" Text="Send" onclick="btnSend_Click" />
        <br />   
    </div>
 
    </form>--%>
    <form action="https://examples.webscript.io/attachments/file" method="post" enctype="multipart/form-data">
    <input type="text" name="email" />
    <input type="file" name="attachment" />
    <button type="submit">
        Send</button>
    </form>
</body>
</html>
