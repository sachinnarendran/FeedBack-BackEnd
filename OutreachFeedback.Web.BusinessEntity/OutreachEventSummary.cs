using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutreachFeedback.Web.BusinessEntity
{
    [Serializable]
    public partial class OutreachEventSummary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]        
        public string EventID { get; set; }
        public string EventMonth { get; set; }
        public string BaseLocation { get; set; }
        public string BeneficiaryName { get; set; }
        public string EventAddress { get; set; }
        public string CouncilName { get; set; }
        public string Project { get; set; }
        public string Category { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public int? TotalNoOfVoluteers { get; set; }
        public int? TotalVolunteerHours { get; set; }
        public int? TotalTravelHours { get; set; }
        public int? OverallVoulteeringHours { get; set; }
        public int? LivesImpacted { get; set; }
        public int ActivityType { get; set; }
        public string Status { get; set; }
        public long? POCID { get; set; }
        public string POCName { get; set; }
        public long? POCContactNumber { get; set; }                                                                           
    }
}
