using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.EF;
using OutreachFeedback.Web.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutreachFeedback.Web.Repository
{
    public class FeedbackOptionsRepository : IFeedbackOptionsRepository
    {
        private readonly IOutreachFeedbackDbContext _dbContext;
        public FeedbackOptionsRepository(IOutreachFeedbackDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<OutreachFeedbackOption> GetFeedbackOptionsList()
        {
            return _dbContext.OutreachFeedbackOptions.ToList();
        }

        public OutreachFeedbackOption SaveFeedbackOptions(OutreachFeedbackOption outreachFeedbackOptions)
        {
            if (outreachFeedbackOptions != null)
            {
                outreachFeedbackOptions.Created_By = "test";
                outreachFeedbackOptions.Created_Date = DateTime.Now;
                _dbContext.OutreachFeedbackOptions.Add(outreachFeedbackOptions);
                _dbContext.SaveChanges();
            }
            return outreachFeedbackOptions;
        }

        public OutreachFeedbackOption UpdateFeedbackOptions(OutreachFeedbackOption outreachFeedbackOptions)
        {
            if (outreachFeedbackOptions != null)
            {
                outreachFeedbackOptions.Updated_By = "test";
                outreachFeedbackOptions.Updated_Date = DateTime.Now;
                _dbContext.OutreachFeedbackOptions.Update(outreachFeedbackOptions);
                _dbContext.SaveChanges();
            }
            return outreachFeedbackOptions;
        }

        public int DeleteFeedbackOptions(int feedbackOptionId)
        {
            var feedbackOption = _dbContext.OutreachFeedbackOptions.Where(x => x.FeedbackOptionID == feedbackOptionId).FirstOrDefault();
            _dbContext.OutreachFeedbackOptions.Remove(feedbackOption);
            _dbContext.SaveChanges();
            return feedbackOptionId;
        }
    }
}
