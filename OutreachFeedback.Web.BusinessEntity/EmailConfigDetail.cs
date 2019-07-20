using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.BusinessEntity
{
    public class EmailConfigDetail
    {
        public string FromMailId { get; set; }
        public string ToMailId { get; set; }
        public string HostAddress { get; set; }
        public string MailMessage { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string AttachmentFilePath { get; set; }
    }
}
