using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutreachFeedback.Web.BusinessEntity
{
    [Serializable]
    public class OutreachRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Role_ID { get; set; }
        public string Role_Title { get; set; }
        public string Description { get; set; }
        public string Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }
    
        public List<OutreachVolunteer> OutreachVolunteers { get; set; }
    }
}
