using OutreachFeedback.Web.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.Interface.Repository
{
    public interface IFeedbackOptionsRepository
    {
        IEnumerable<OutreachFeedbackOption> GetFeedbackOptionsList();
        OutreachFeedbackOption SaveFeedbackOptions(OutreachFeedbackOption outreachFeedbackOptions);
        OutreachFeedbackOption UpdateFeedbackOptions(OutreachFeedbackOption outreachFeedbackOptions);
        int DeleteFeedbackOptions(int feedbackOptionId);
    }
}
