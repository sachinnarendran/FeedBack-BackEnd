using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.Interface.Repository;
using OutreachFeedback.Web.Interface.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.BusinessLogic
{
    public class FeedbackValidator : IFeedbackValidator
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackValidator(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public string SendEmail(EmailConfigDetail emailConfig, string feedbackType)
        {
            EmailDetail email = new EmailDetail();
            string output = "";
            var emailContents = _feedbackRepository.GetFeedbackOptionsList(feedbackType);
            emailConfig.ToMailId = "usha.ucet@gmail.com";
            emailConfig.Subject = feedbackType;
            emailConfig.Body = "";
            output = email.GenerateEmail(emailConfig);
            return output;
        }

    }
}
