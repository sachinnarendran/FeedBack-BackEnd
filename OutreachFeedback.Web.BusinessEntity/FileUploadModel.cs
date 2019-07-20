using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.BusinessEntity
{
    public class FileUploadModel
    {
       
        public string Filename { get; set; }
        public FileData AllFiledata { get; set; }


    }
    public class FileData
    {
        public List<OutreachEventInformation> OutreachEventInformation { get; set; }
        public List<OutreachFeedbackResponse> OutreachFeedbackResponses { get; set; }
        public List<OutreachVolunteer> OutreachVolunteers { get; set; }
    }
    public class RootModel
    {
        public List<object> Objectlist { get; set; }
    }
}
