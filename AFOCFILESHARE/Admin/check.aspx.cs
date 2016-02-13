using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;

namespace AFOCFILESHARE.Admin
{
    public partial class check : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        ///protected void btnSend_Click(object sender, EventArgs e)
        //{
        //    MailMessage mail = new MailMessage();
        //    try
        //    {
        //        mail.To.Add("admin@yourdomain.com");
        //        mail.From = new MailAddress(txtFrom.Text);
        //        mail.Subject = txtSubject.Text;
        //        string Body = txtBody.Text;
        //        mail.Body = Body;
        //        mail.Attachments.Add(new Attachment(fuAttachment.FileContent, System.IO.Path.GetFileName(fuAttachment.FileName)));
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = ConfigurationManager.AppSettings["SMTP"];
        //        smtp.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //    finally
        //    {
        //        mail.Dispose();
        //    }
       // }
    }
}