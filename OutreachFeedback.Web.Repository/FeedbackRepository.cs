using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.EF;
using OutreachFeedback.Web.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  

namespace OutreachFeedback.Web.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly IOutreachFeedbackDbContext _dbContext;
        public FeedbackRepository(IOutreachFeedbackDbContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<OutreachFeedbackOption> GetFeedbackOptionsList(string feedbackType)
        {
            return (from ofopt in _dbContext.OutreachFeedbackOptions
                    join ofq in _dbContext.OutreachFeedbackQuestions
                    on ofopt.QuestionID equals ofq.QuestionID
                    where ofopt.Feedback_Type == feedbackType
                    select ofopt).ToList();
        }
        public IEnumerable<OutreachVolunteer> GetVolunteerDetails(string feedbackType)
        {
            return _dbContext.OutreachVolunteer
           .Where(m => m.IsRegister == 1).ToList();
        }
    }
}
