using OutreachFeedback.Web.BusinessEntity;
using System.Collections.Generic;

namespace OutreachFeedback.Web.Interface.Repository
{
    public interface IQuestionsRepository
    {
        IEnumerable<OutreachFeedbackQuestion> GetFeedbackQuestionsList();
        OutreachFeedbackQuestion SaveFeedbackQuestions(OutreachFeedbackQuestion outreachFeedbackQuestion);
        OutreachFeedbackQuestion UpdateFeedbackQuestions(OutreachFeedbackQuestion outreachFeedbackQuestion);
        int DeleteFeedbackQuestions(int questionId);
    }
}
