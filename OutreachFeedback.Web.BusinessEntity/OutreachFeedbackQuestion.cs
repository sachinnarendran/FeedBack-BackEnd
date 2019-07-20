using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutreachFeedback.Web.BusinessEntity
{
    [Serializable]
    public class OutreachFeedbackQuestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionID { get; set; }
        [Required]
        public string QuestionName { get; set; }
        [Required]
        public string Created_By { get; set; }
        [Required]
        public DateTime? Created_Date { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }
        public List<OutreachFeedbackOption> OutreachFeedbackOptions { get; set; }
        public List<OutreachFeedbackResponse> OutreachFeedbackResponses { get; set; }
    }
}
