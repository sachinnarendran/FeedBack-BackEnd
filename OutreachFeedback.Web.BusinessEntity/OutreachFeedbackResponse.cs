using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutreachFeedback.Web.BusinessEntity
{
    [Serializable]
    public partial class OutreachFeedbackResponse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FeedbackResponseID { get; set; }
        public int FeedbackOptionID { get; set; }
        public int QuestionID { get; set; }
        public string EventID { get; set; }
        public int? EmployeeID { get; set; }
        public int? SmileyRating { get; set; }
        public int? IsResponse { get; set; }
        public string Feedback_Response { get; set; }
    
        public OutreachEventInformation OutreachEventInformation { get; set; }
        public OutreachFeedbackOption OutreachFeedbackOption { get; set; }
        public OutreachFeedbackQuestion OutreachFeedbackQuestion { get; set; }
    }
}
