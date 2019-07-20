using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.Interface.Repository;

namespace OutreachFeedback.Web.Rest.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class FeedbackOptionsController : ControllerBase
    {
        private readonly IFeedbackOptionsRepository _feedbackOptionsRepository;

        public FeedbackOptionsController(IFeedbackOptionsRepository feedbackOptionsRepository)
        {
            _feedbackOptionsRepository = feedbackOptionsRepository;
        }

        [HttpGet]
        [Route("GetFeedbackOptionsList")]
        public IEnumerable<OutreachFeedbackOption> GetFeedbackOptionsList()
        {
            return _feedbackOptionsRepository.GetFeedbackOptionsList();
        }

        [HttpPost]
        [Route("SaveFeedbackOptions")]
        public OutreachFeedbackOption SaveFeedbackOptions([FromBody] OutreachFeedbackOption outreachFeedbackOption)
        {
            return _feedbackOptionsRepository.SaveFeedbackOptions(outreachFeedbackOption);
        }

        [HttpPut]
        [Route("UpdateFeedbackOptions")]
        public OutreachFeedbackOption UpdateFeedbackOptions([FromBody] OutreachFeedbackOption outreachFeedbackOption)
        {
            return _feedbackOptionsRepository.UpdateFeedbackOptions(outreachFeedbackOption);
        }

        [HttpDelete]
        [Route("DeleteFeedbackOptions")]
        public int DeleteFeedbackOptions(int feedbackOptionID)
        {
            return _feedbackOptionsRepository.DeleteFeedbackOptions(feedbackOptionID);
        }
    }
}