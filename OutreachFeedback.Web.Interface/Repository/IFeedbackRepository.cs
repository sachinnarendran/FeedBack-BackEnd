using OutreachFeedback.Web.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.Interface.Repository
{
    public interface IFeedbackRepository
    {
        IEnumerable<OutreachFeedbackOption> GetFeedbackOptionsList(string feedbackType);
        IEnumerable<OutreachVolunteer> GetVolunteerDetails(string feedbackType);
    }
}
