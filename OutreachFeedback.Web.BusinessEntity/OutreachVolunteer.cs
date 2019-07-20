using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutreachFeedback.Web.BusinessEntity
{
    [Serializable]
    public class OutreachVolunteer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Event_ID { get; set; }
        public string Event_Name { get; set; }
        public DateTime? Event_Date { get; set; }
        public string Beneficiary_Name { get; set; }
        public string Base_Location { get; set; }

        [Key]
        public int Volunteer_ID { get; set; }
        public int? Employee_ID { get; set; }
        public int Role_ID { get; set; }
                                                
        public int? IsRegister { get; set; }
        public int? Unattended { get; set; }
        public string Volunteer_Details { get; set; }
        public int? IsEmailSent { get; set; }           
    }
}
