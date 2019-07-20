using OutreachFeedback.Web.BusinessEntity;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace OutreachFeedback.Web.BusinessLogic
{
    public class EmailDetail
    {
        string FromMailId = string.Empty;
        string ToMailId = string.Empty;
        string HostAddress = string.Empty;
        string Body = string.Empty;
        string Subject = string.Empty;
        string AttachmentFilePath = string.Empty;
        string retVal = string.Empty;
        public string GenerateEmail(EmailConfigDetail emailConfig)
        {
            MailMessage mailMessage = new MailMessage();
            try
            {
                if (emailConfig != null)
                {
                    FromMailId = emailConfig.FromMailId;
                    ToMailId = emailConfig.ToMailId;
                    HostAddress = emailConfig.HostAddress;
                    Body = emailConfig.Body;
                    Subject = emailConfig.Subject;
                    AttachmentFilePath = emailConfig.AttachmentFilePath;
                }

                mailMessage.To.Add(ToMailId);
                mailMessage.From = new MailAddress(FromMailId);
                mailMessage.Subject = Subject;
                mailMessage.Body = Body;
                mailMessage.IsBodyHtml = true;
                if (!string.IsNullOrWhiteSpace(AttachmentFilePath))
                {
                    Attachment attachment = new Attachment(AttachmentFilePath, MediaTypeNames.Application.Pdf);
                    //ContentDisposition disposition = attachment.ContentDisposition;
                    string guid = attachment.Name.Split('_')[2];
                    attachment.Name = attachment.Name.Replace('_' + guid, string.Empty);
                    mailMessage.Attachments.Add(attachment);
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.Credentials = new System.Net.NetworkCredential();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback =
                  delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                  { return true; };

                smtp.Send(mailMessage);
                DisposeMailAttachments(mailMessage);
                retVal = "Email sent successfully";
                return retVal;
            }
            catch (Exception ex)
            {
                DisposeMailAttachments(mailMessage);
                throw ex;
            }
            finally
            {
                DisposeMailAttachments(mailMessage);
            }

        }

        private void DisposeMailAttachments(MailMessage ms)
        {
            if (ms != null)
            {
                foreach (Attachment attachFile in ms.Attachments)
                {
                    attachFile.Dispose();
                }
                ms.Attachments.Dispose();
                ms = null;
            }
        }
    }
}
