using OutreachFeedback.Web.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace OutreachFeedback.Web.Helpers
{
    public class FileContentMapper:IFileContentMapper
    {
        public List<OutreachEventInformation> EventInformationMapper(dynamic arraydata)
        {
            List<OutreachEventInformation> outreachEventInformation = new List<OutreachEventInformation>();
            OutreachEventInformation eventInformation = new OutreachEventInformation();
            
            for (int i=0;i<arraydata.Count;i++)
            {                
                eventInformation = new OutreachEventInformation
                {
                    EventID = arraydata[i][0],
                    BaseLocation = arraydata[i][1],
                    BeneficiaryName = arraydata[i][2],
                    CouncilName = arraydata[i][3],
                    EventName = arraydata[i][4],
                    EventDescription = arraydata[i][5],
                    EventDate= CreateValidDate(arraydata[i][6]),
                    EmployeeID = Convert.ToInt32(arraydata[i][7]),
                    EmployeeName = arraydata[i][8],
                    VoluteerHours = Convert.ToInt32(arraydata[i][9]),
                    TravelHours = Convert.ToInt32(arraydata[i][10]),
                    LivesImpacted = Convert.ToInt32(arraydata[1][11]),
                    BusinessUnit = arraydata[i][12],
                    Status = arraydata[i][13],
                    IiepCategory = arraydata[i][14]
                };
                outreachEventInformation.Add(eventInformation);
            }
            
            return outreachEventInformation;
        }

        public List<OutreachEventSummary> EventSummaryMapper(dynamic arraydata)
        {
            List<OutreachEventSummary> outreachEventSummaryList = new List<OutreachEventSummary>();
            OutreachEventSummary outreachEventSummary = new OutreachEventSummary();
            for (int i = 0; i < arraydata.Count; i++)
            {
                outreachEventSummary = new OutreachEventSummary
                {
                    EventID = arraydata[i][0],
                    EventMonth = arraydata[i][1],
                    BaseLocation = arraydata[i][2],
                    BeneficiaryName = arraydata[i][3],
                    EventAddress = arraydata[i][4],
                    CouncilName = arraydata[i][5],
                    Project = arraydata[i][6],
                    Category = arraydata[i][7],
                    EventName = arraydata[i][8],
                    EventDescription = arraydata[i][9],
                    EventDate = CreateValidDate(arraydata[i][10]),
                    TotalNoOfVoluteers = Convert.ToInt32(arraydata[i][11]),
                    TotalVolunteerHours = Convert.ToInt32(arraydata[i][12]),
                    TotalTravelHours = Convert.ToInt32(arraydata[i][13]),
                    OverallVoulteeringHours = Convert.ToInt32(arraydata[i][14]),
                    LivesImpacted = Convert.ToInt32(arraydata[i][15]),
                    ActivityType = Convert.ToInt32(arraydata[i][16]),
                    Status = arraydata[i][17],
                    POCID = Convert.ToInt64(arraydata[i][18]),
                    POCName = arraydata[i][19],
                    POCContactNumber = Convert.ToInt64(arraydata[i][20])
                };
                outreachEventSummaryList.Add(outreachEventSummary);
            }
            return outreachEventSummaryList;
        }

        public List<OutreachVolunteer> UnAttendedEventVounteerMapper(dynamic arrayData)
        {
            List<OutreachVolunteer> outreachVolunteersList = new List<OutreachVolunteer>();
            OutreachVolunteer outreachVolunteer = new OutreachVolunteer();
            for(int i = 0; i< arrayData.Count;i++)
            {
                outreachVolunteer = new OutreachVolunteer
                {
                    Event_ID = arrayData[i][0],
                    Event_Name = arrayData[i][1],                    
                    Beneficiary_Name = arrayData[i][2],
                    Base_Location = arrayData[i][3],
                    Event_Date = CreateValidDate(arrayData[i][4]),
                    Volunteer_ID = Convert.ToInt32(arrayData[i][5]),
                    Unattended = 1,
                    IsRegister = 1,
                    Role_ID = 3
                };
                outreachVolunteersList.Add(outreachVolunteer);
            }
            return outreachVolunteersList;
        }

        public List<OutreachVolunteer> NotRegisteredVolunteerMapper(dynamic arrayData)
        {
            List<OutreachVolunteer> outreachVolunteersList = new List<OutreachVolunteer>();
            OutreachVolunteer outreachVolunteer = new OutreachVolunteer();
            for (int i = 0; i < arrayData.Count; i++)
            {
                outreachVolunteer = new OutreachVolunteer
                {
                    Event_ID = arrayData[i][0],
                    Event_Name = arrayData[i][1],
                    Beneficiary_Name = arrayData[i][2],
                    Base_Location = arrayData[i][3],
                    Event_Date = CreateValidDate(arrayData[i][4]),
                    Volunteer_ID = Convert.ToInt32(arrayData[i][5]),
                    IsRegister = 0,                    
                    Role_ID = 3
                };
                outreachVolunteersList.Add(outreachVolunteer);
            }
            return outreachVolunteersList;
        }
        public List<OutreachVolunteer> RegisteredVolunteerMapper(dynamic arrayData)
        {
            List<OutreachVolunteer> outreachVolunteersList = new List<OutreachVolunteer>();
            OutreachVolunteer outreachVolunteer = new OutreachVolunteer();
            for (int i = 0; i < arrayData.Count; i++)
            {
                outreachVolunteer = new OutreachVolunteer
                {
                    Event_ID = arrayData[i][0],
                    Event_Name = arrayData[i][1],
                    Beneficiary_Name = arrayData[i][2],
                    Base_Location = arrayData[i][3],
                    Event_Date = CreateValidDate(arrayData[i][4]),
                    Volunteer_ID = Convert.ToInt32(arrayData[i][5]),
                    IsRegister = 1,
                    Role_ID = 3
                };
                outreachVolunteersList.Add(outreachVolunteer);
            }
            return outreachVolunteersList;
        }


        public DateTime CreateValidDate(dynamic dateToBeConverted)
        {
            GregorianCalendar gregCal = new GregorianCalendar();

            string newdate = Convert.ToString(dateToBeConverted).Replace('-', '/');

            DateTime dtDate = new DateTime(gregCal.ToFourDigitYear(Convert.ToInt32(newdate.Substring(6, 2))), Convert.ToInt32(newdate.Substring(3, 2)), Convert.ToInt32(newdate.Substring(0, 2)));
            
            return dtDate;
        }
    }
}
