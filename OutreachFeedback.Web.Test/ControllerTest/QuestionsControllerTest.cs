using Moq;
using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.Interface.Repository;
using OutreachFeedback.Web.Rest.Controller;
using OutreachFeedback.Web.Test.MockupData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OutreachFeedback.Web.Test
{
    public class QuestionsControllerTest
    {
        private readonly Mock<IQuestionsRepository> questionsRepository;
        private readonly QuestionsController questionsController;
        public QuestionsControllerTest()
        {
            questionsRepository = new Mock<IQuestionsRepository>();
            questionsController = new QuestionsController(questionsRepository.Object);
        }

        [Fact]
        public void GetFeedbackQuestionsList()
        {
            var questionList = QuestionsMockup.GetFeedbackQuestionsList();
            // Arrange
            questionsRepository.Setup(rep => rep.GetFeedbackQuestionsList()).Returns(questionList);
            // Act
            var result = questionsController.GetFeedbackQuestionsList();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void SaveFeedbackQuestions()
        {
            // Arrange
            var question = QuestionsMockup.GetFeedbackQuestionsList();
            questionsRepository.Setup(m => m.SaveFeedbackQuestions(question[0])).Returns(question[0]);
            // Act
            var result = questionsController.SaveFeedbackQuestions(question[0]);
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateFeedbackQuestions()
        {
            var question = QuestionsMockup.GetFeedbackQuestionsList();
            questionsRepository.Setup(m => m.UpdateFeedbackQuestions(question[0])).Returns(question[0]);
            var result = questionsController.UpdateFeedbackQuestions(question[0]);
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteFeedbackQuestions()
        {
            questionsRepository.Setup(m => m.DeleteFeedbackQuestions(1)).Returns(1);
            var result = questionsController.DeleteFeedbackQuestions(1);
            Assert.Equal(1, 1);
        }
    }
}
