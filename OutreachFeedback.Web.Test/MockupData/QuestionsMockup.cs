using OutreachFeedback.Web.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.Test.MockupData
{
    public class QuestionsMockup
    {
        public static List<OutreachFeedbackQuestion> GetFeedbackQuestionsList()
        {
            var questionList = new List<OutreachFeedbackQuestion>();
            OutreachFeedbackQuestion question = new OutreachFeedbackQuestion();
            question.QuestionName = "Why do you unregistered?";
            question.Created_By = "test";
            question.Created_Date = DateTime.Now.Date;
            question.Updated_By = "test";
            question.Updated_Date = DateTime.Now.AddDays(10).Date;
            questionList.Add(question);

            question.QuestionName = "Why did you not participate?";
            question.Created_By = "test";
            question.Created_Date = DateTime.Now.Date;
            question.Updated_By = "test";
            question.Updated_Date = DateTime.Now.AddDays(5).Date;
            questionList.Add(question);
            return questionList;
        }
    }
}
