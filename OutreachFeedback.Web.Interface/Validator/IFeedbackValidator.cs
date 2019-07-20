using OutreachFeedback.Web.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.Interface.Validator
{
    public interface IFeedbackValidator
    {
        string SendEmail(EmailConfigDetail emailConfig, string feedbackType);
    }
}
