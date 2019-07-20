using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutreachFeedback.Web.BusinessEntity
{
    [Serializable]
    public class OutreachEventInformation
    {
        [Key]
        public string EventID { get; set; }
        public string BaseLocation { get; set; }
        public string BeneficiaryName { get; set; }
        public string CouncilName { get; set; }
        [Key]
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventDate { get; set; }

        [Key]
        public int? EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int? VoluteerHours { get; set; }
        public int? TravelHours { get; set; }
        public int? LivesImpacted { get; set; }
        public string BusinessUnit { get; set; }
        public string Status { get; set; }
        public string IiepCategory { get; set; }
                        
    }
}
