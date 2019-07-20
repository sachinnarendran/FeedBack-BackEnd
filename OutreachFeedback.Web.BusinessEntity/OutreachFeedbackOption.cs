using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutreachFeedback.Web.BusinessEntity
{
    [Serializable]
    public class OutreachFeedbackOption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FeedbackOptionID { get; set; }

        public int QuestionID { get; set; }
        public string FeedbackOption_Description { get; set; }
        public string Feedback_Type { get; set; }
        public string Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }
        public OutreachFeedbackQuestion OutreachFeedbackQuestion { get; set; }
        public List<OutreachFeedbackResponse> OutreachFeedbackResponses { get; set; }
    }
}
