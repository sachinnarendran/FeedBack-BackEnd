using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.EF;
using OutreachFeedback.Web.Interface;
using OutreachFeedback.Web.Interface.Repository;

namespace OutreachFeedback.Web.Rest.Controller
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionsController(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        [HttpGet]
        [Route("GetFeedbackQuestionsList")]
        public IEnumerable<OutreachFeedbackQuestion> GetFeedbackQuestionsList()
        {
            return _questionsRepository.GetFeedbackQuestionsList();
        }

        [HttpPost]
        [Route("SaveFeedbackQuestions")]
        public OutreachFeedbackQuestion SaveFeedbackQuestions([FromBody] OutreachFeedbackQuestion outreachFeedbackQuestion)
        {
            return _questionsRepository.SaveFeedbackQuestions(outreachFeedbackQuestion);
        }

        [HttpPut]
        [Route("UpdateFeedbackQuestions")]
        public OutreachFeedbackQuestion UpdateFeedbackQuestions([FromBody] OutreachFeedbackQuestion outreachFeedbackQuestion)
        {
            return _questionsRepository.UpdateFeedbackQuestions(outreachFeedbackQuestion);
        }

        [HttpDelete]
        [Route("DeleteFeedbackQuestions")]
        public int DeleteFeedbackQuestions(int questionId)
        {
            return _questionsRepository.DeleteFeedbackQuestions(questionId);
        }
    }
}
