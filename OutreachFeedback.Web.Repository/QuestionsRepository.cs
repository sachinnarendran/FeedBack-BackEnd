using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.EF;
using OutreachFeedback.Web.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OutreachFeedback.Web.Repository
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly IOutreachFeedbackDbContext _dbContext;
        public QuestionsRepository(IOutreachFeedbackDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<OutreachFeedbackQuestion> GetFeedbackQuestionsList()
        {
            return _dbContext.OutreachFeedbackQuestions.ToList();
        }

        public OutreachFeedbackQuestion SaveFeedbackQuestions(OutreachFeedbackQuestion outreachFeedbackQuestion)
        {
            if (outreachFeedbackQuestion != null)
            {
                outreachFeedbackQuestion.Created_By = "test";
                outreachFeedbackQuestion.Created_Date = DateTime.Now;
                _dbContext.OutreachFeedbackQuestions.Add(outreachFeedbackQuestion);
                _dbContext.SaveChanges();
            }
            return outreachFeedbackQuestion;
        }

        public OutreachFeedbackQuestion UpdateFeedbackQuestions(OutreachFeedbackQuestion outreachFeedbackQuestion)
        {
            if (outreachFeedbackQuestion != null)
            {
                outreachFeedbackQuestion.Updated_By = "test";
                outreachFeedbackQuestion.Updated_Date = DateTime.Now;
                _dbContext.OutreachFeedbackQuestions.Update(outreachFeedbackQuestion);
                _dbContext.SaveChanges();
            }
            return outreachFeedbackQuestion;
        }

        public int DeleteFeedbackQuestions(int questionId)
        {
            var questions = _dbContext.OutreachFeedbackQuestions.Where(x => x.QuestionID == questionId).FirstOrDefault();
            _dbContext.OutreachFeedbackQuestions.Remove(questions);
            _dbContext.SaveChanges();
            return questionId;
        }
    }
}
