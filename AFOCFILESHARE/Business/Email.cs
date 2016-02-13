using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;

namespace AFOCFILESHARE.Business
{
    public class Email
    {
        public static void sendMail(string sFrom, string sTo, string sBcc, string sCC, string sSubject, string sBody)
        {
            try
            {
                MailMessage message = new MailMessage();          //Here we will create object of MailMessage class.
                message.From = new MailAddress(sFrom);       //Initilize From in mail address.
                message.To.Add(new MailAddress(sTo));        //Initilize To in mail address.


                if (!string.IsNullOrEmpty(sBcc))           //Check whether sBcc is not empty.
                {
                    message.Bcc.Add(new MailAddress(sBcc));    //Add sBcc in mail address.
                }


                if (!string.IsNullOrEmpty(sCC))          //Check whether sCC is not empty.
                {
                    message.CC.Add(new MailAddress(sCC));      //Add CC in mail address.
                }

               // MailMessage mail = new MailMessage();
              
               //// string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
               // Attachment myAttachment = new Attachment(FileUpload1.FileContent, fileName);
               // mail.Attachments.Add(myAttachment);

              //  string attachedFile =(fileName);
                //Attachment myAttachment = new Attachment(fileName, MediaTypeNames.Application.Octet);
                //message.Attachments.Add(myAttachment);

                message.Subject = sSubject;        //Add subject in mail message.
                message.Body = sBody;            //Add body in mail message.
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;   //Set priority of mail message.
                //SmtpClient client = new SmtpClient();//Create an object of Smtp client.
                //client.EnableSsl = true;
                //client.Send(message);            //Send message by using send() method.
           
                SmtpClient smtp = new SmtpClient();//Create an object of Smtp client.

                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "infoafocdubai@gmail.com";

                NetworkCred.Password = "welcomeafoc";

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;

                smtp.Send(message);
                message = null;

                smtp = null;


            }
            catch
            {
            }
        }





        public static void sendMailAttachment(string sFrom, string sTo, string sBcc, string sCC, string sSubject, string sBody, Attachment attachemnt)
        {
            try
            {
                MailMessage message = new MailMessage();          //Here we will create object of MailMessage class.
                message.From = new MailAddress(sFrom);       //Initilize From in mail address.
                message.To.Add(new MailAddress(sTo));        //Initilize To in mail address.


                if (!string.IsNullOrEmpty(sBcc))           //Check whether sBcc is not empty.
                {
                    message.Bcc.Add(new MailAddress(sBcc));    //Add sBcc in mail address.
                }


                if (!string.IsNullOrEmpty(sCC))          //Check whether sCC is not empty.
                {
                    message.CC.Add(new MailAddress(sCC));      //Add CC in mail address.
                }

                // MailMessage mail = new MailMessage();

                //// string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                // Attachment myAttachment = new Attachment(FileUpload1.FileContent, fileName);
                // mail.Attachments.Add(myAttachment);

                //  string attachedFile =(fileName);
                //Attachment myAttachment = new Attachment(fileName, MediaTypeNames.Application.Octet);
                //message.Attachments.Add(myAttachment);
                message.Attachments.Add(attachemnt);
                message.Subject = sSubject;        //Add subject in mail message.
                message.Body = sBody;            //Add body in mail message.
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;   //Set priority of mail message.
                //SmtpClient client = new SmtpClient();//Create an object of Smtp client.
                //client.EnableSsl = true;
                //client.Send(message);            //Send message by using send() method.

                SmtpClient smtp = new SmtpClient();//Create an object of Smtp client.

                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "infoafocdubai@gmail.com";

                NetworkCred.Password = "welcomeafoc";

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;

                smtp.Send(message);
                message = null;

                smtp = null;


            }
            catch
            {
            }
        }
    }
}