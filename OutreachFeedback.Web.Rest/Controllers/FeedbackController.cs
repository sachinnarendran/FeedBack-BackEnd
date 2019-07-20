using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.BusinessLogic;
using OutreachFeedback.Web.Interface.Repository;
using OutreachFeedback.Web.Interface.Validator;

namespace OutreachFeedback.Web.Rest.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IFeedbackValidator _feedbackValidator;
        private EmailSettings emailSettings { get; set; }
        private EmailConfigDetail emailConfigDetail { get; set; }

        public FeedbackController(IFeedbackRepository feedbackRepository, IOptions<EmailSettings> emailSettings, IFeedbackValidator feedbackValidator)
        {
            _feedbackRepository = feedbackRepository;
            _feedbackValidator = feedbackValidator;
            emailConfigDetail = new EmailConfigDetail();
            this.emailSettings = emailSettings.Value;
            emailConfigDetail.FromMailId = this.emailSettings.FromAddress;
            emailConfigDetail.HostAddress = this.emailSettings.HostServer;
        }

        [HttpGet]
        [Route("GetFeedbackOptionsList")]
        public IEnumerable<OutreachFeedbackOption> GetFeedbackOptionsList(string feedbackType)
        {
            return _feedbackRepository.GetFeedbackOptionsList(feedbackType);
        }

        [HttpGet]
        [Route("SendEmail")]
        public string SendEmail(string feedbackType)
        {
            return _feedbackValidator.SendEmail(emailConfigDetail, feedbackType);
        }
    }
}