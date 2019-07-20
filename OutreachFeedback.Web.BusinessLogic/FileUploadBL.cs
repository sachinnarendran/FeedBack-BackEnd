using Newtonsoft.Json;
using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.EF;
using OutreachFeedback.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.BusinessLogic
{
    public class FileUploadBL : IFileUploadBL
    {
        private IFileContentMapper _fileContentMapper;

        private IOutreachFeedbackDbContext _outreachFeedbackDbContext;

        public FileUploadBL(IFileContentMapper fileContentMapper,IOutreachFeedbackDbContext outreachFeedbackDbContext)
        {
            _fileContentMapper = fileContentMapper;
            _outreachFeedbackDbContext = outreachFeedbackDbContext;
        }

        /// <summary>
        /// Save Content Business Layer Method
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public int SaveFileContent(object data,string filename)
        {
            
            int savedToDb = 0;
            var serializer = JsonConvert.SerializeObject(data);
            var result = JsonConvert.DeserializeObject<dynamic>(serializer);
            
            if (filename.Contains("Event") && filename.Contains("Information"))
            {
                List<OutreachEventInformation> outreachEventInformation = new List<OutreachEventInformation>();
                outreachEventInformation = _fileContentMapper.EventInformationMapper(result);
                _outreachFeedbackDbContext.OutreachEventInformation.AddRange(outreachEventInformation);
                savedToDb = _outreachFeedbackDbContext.SaveChanges();
                return savedToDb;
            }
            if(filename.Contains("Event") && filename.Contains("Summary"))
            {
                List<OutreachEventSummary> outreachEventSummary = new List<OutreachEventSummary>();
                outreachEventSummary = _fileContentMapper.EventSummaryMapper(result);
                _outreachFeedbackDbContext.OutreachEventSummary.AddRange(outreachEventSummary);
                savedToDb = _outreachFeedbackDbContext.SaveChanges();
                return savedToDb;
            }
            if(filename.Contains("Volunteer") && filename.Contains("Not") && filename.Contains("Attend"))
            {
                List<OutreachVolunteer> outreachVolunteers = new List<OutreachVolunteer>();
                outreachVolunteers = _fileContentMapper.UnAttendedEventVounteerMapper(result);
                _outreachFeedbackDbContext.OutreachVolunteer.AddRange(outreachVolunteers);
                savedToDb = _outreachFeedbackDbContext.SaveChanges();
                return savedToDb;
            }
            if(filename.Contains("Volunteer") && filename.Contains("Unregistered"))
            {
                List<OutreachVolunteer> outreachVolunteers = new List<OutreachVolunteer>();
                outreachVolunteers = _fileContentMapper.NotRegisteredVolunteerMapper(result);
                _outreachFeedbackDbContext.OutreachVolunteer.AddRange(outreachVolunteers);
                savedToDb = _outreachFeedbackDbContext.SaveChanges();
                return savedToDb;
            }
            if (filename.Contains("Volunteer") && filename.Contains("Registered"))
            {
                List<OutreachVolunteer> outreachVolunteers = new List<OutreachVolunteer>();
                outreachVolunteers = _fileContentMapper.RegisteredVolunteerMapper(result);
                _outreachFeedbackDbContext.OutreachVolunteer.AddRange(outreachVolunteers);
                savedToDb = _outreachFeedbackDbContext.SaveChanges();
                return savedToDb;
            }
            return savedToDb;
            
        }
    }
}
