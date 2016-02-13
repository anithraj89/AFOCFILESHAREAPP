using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AFOCFILESHARE.Business;
using System.Net.Mail;
using System.IO;

namespace AFOCFILESHARE.Admin
{
    public partial class UploadFiles : System.Web.UI.Page
    {
       
        protected AFOCFILESHARE.Business.FileUpload obj = new AFOCFILESHARE.Business.FileUpload();
        protected void Page_Load(object sender, EventArgs e)
        {
                          
        }

        protected void btnsubmit_Click1(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                obj.UserId = Convert.ToInt32(Session["userId"]);
                obj.FileName = FileUpload1.FileName;
                obj.FileSize = FileUpload1.FileContent.Length;
                //get file extension
                obj.Extension = obj.FileName.Substring(obj.FileName.LastIndexOf(".") + 1);
                string fileType = null;
                switch (obj.Extension)
                {
                    case "doc":
                        fileType = "application/vnd.ms-word";
                        break;
                    case "docx":
                        fileType = "application/vnd.ms-word";
                        break;
                    case "xls":
                        fileType = "application/vnd.ms-excel";
                        break;
                    case "xlsx":
                        fileType = "application/vnd.ms-excel";
                        break;
                    case "jpg":
                        fileType = "image/jpg";
                        break;
                    case "png":
                        fileType = "image/png";
                        break;
                    case "gif":
                        fileType = "image/gif";
                        break;
                    case "pdf":
                        fileType = "application/pdf";
                        break;

                    default:
                        fileType = "Unknown";
                        break;
                }
                obj.FileType = fileType.ToString();
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + obj.FileName.Trim()));
                
                obj.FilePath = "~/Upload/" + obj.FileName.Trim();


                MailMessage mail = new MailMessage();
                //////System.Net.Mail.Attachment attachment;
                //////attachment = new System.Net.Mail.Attachment("your attachment file");
                //////mail.Attachments.Add(attachment);


                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                Attachment myAttachment = new Attachment(FileUpload1.FileContent, fileName);
                mail.Attachments.Add(myAttachment);
                //set the file type based on File Extension

                //if (FileUpload1.PostedFile != null)
                //{
                //    try
                //    {
                //        string strFileName =
                //        System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                //        Attachment attachFile =
                //        new Attachment(FileUpload1.PostedFile.InputStream, strFileName);
                //        mm.Attachments.Add(attachFile);
                //    }
                //    catch
                //    {

                //    }
                //}



               /// anith
//                private Boolean SendMailUsingGmail(String mailTo, String mailText, String attachmentFileWithPath)
// {
//     Boolean sendMailResult;
//     try
//     {
//         SmtpClient smtpServer = new SmtpClient();
//         smtpServer.Credentials = new System.Net.NetworkCredential(mailFromId, mailFromPassword);
//         smtpServer.Port = 25;
//         smtpServer.Host = "smtp.gmail.com";
//         MailMessage sampleMail = new MailMessage();
//         sampleMail.From = new MailAddress(mailFromId);
//         sampleMail.Subject = "Mail";
//         string file = attachmentFileWithPath; //file path
//         Attachment data = new Attachment(file, MediaTypeNames.Application.Zip);
//         ContentDisposition disposition = data.ContentDisposition;
//         disposition.CreationDate = System.IO.File.GetCreationTime(file);
//         disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
//         disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
//         // Add the file attachment to this e-mail message.
//         sampleMail.Attachments.Add(data);
//         sampleMail.To.Add(mailTo);
//         sampleMail.Body = mailText;
//         smtpServer.Send(sampleMail);
//         sendMailResult = true;
//         return sendMailResult;
//     }
//     catch (Exception ex)
//     {
//         string exceptionString = ex.Message;
//         sendMailResult = false;
//         return sendMailResult;
//     }
//     finally
//     {
//     }
 
// }
/////anith


                obj.INSERT_File_DETAILS(obj);
                //divLoginError.Visible = false;
               // AFOCFILESHARE.Business.Email.Attachments.Add(new Attachment(fuAttachment.FileContent, System.IO.Path.GetFileName(fuAttachment.FileName)));

                //MailMessage mail = new MailMessage();
                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment("your attachment file");
                //mail.Attachments.Add(attachment);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The file has been uploaded.')", true);
              //  AFOCFILESHARE.Business.Email.sendMail("infoafocdubai@gmail.com", txtEmail.Text, "", "", "AFOC File Portal Registration", "<pre><h1>AFOC File Portal Registration</h1><h3><br/><br/>Dear " + txtFirstName.Text + ",<br/>        We have received a request from AFOC that you have registered an account as a User in AFOC File Portal. We are sending your username and password along with this email. Please note the username and password for using the AFOC File Portal website.<br/><br/>        Your username for AFOC File Portal login is.<br/>        " + txtUsername.Text + "<br/>        Your password for AFOC File Portal login is.<br/>        " + txtPassword.Text + "<br/><br/>        If you do not registered, kindly inform us.<br/><br/> Thank You,<br/> afocfileapp.com <br/> P.O Box:6382,<br/> Abu Dhabi,<br/> United Arab Emirates <br/><br/>Request generated by: <br/> URL:<a href='http://www.afocfileapp.com'> http://www.afocfileapp.com </a></h3></pre>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The file has been uploaded.');window.location = 'ListFiles.aspx';", true);
            }
        }

       
    }
}