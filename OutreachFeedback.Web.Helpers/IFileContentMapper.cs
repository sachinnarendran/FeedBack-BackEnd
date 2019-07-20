using OutreachFeedback.Web.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.Helpers
{
    public interface IFileContentMapper
    {
        List<OutreachEventInformation> EventInformationMapper(dynamic fileContent);
        List<OutreachEventSummary> EventSummaryMapper(dynamic fileContent);
        List<OutreachVolunteer> UnAttendedEventVounteerMapper(dynamic fileContent);
        List<OutreachVolunteer> NotRegisteredVolunteerMapper(dynamic fileContent);
        List<OutreachVolunteer> RegisteredVolunteerMapper(dynamic fileContent);
    }
}
