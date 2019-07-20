using Microsoft.EntityFrameworkCore;
using OutreachFeedback.Web.BusinessEntity;

namespace OutreachFeedback.Web.EF
{
    public interface IOutreachFeedbackDbContext
    {
        DbSet<AuditLog> AuditLogs { get; set; }
        DbSet<ErrorLog> ErrorLogs { get; set; }
        DbSet<OutreachEventInformation> OutreachEventInformation { get; set; }
        DbSet<OutreachEventSummary> OutreachEventSummary { get; set; }
        DbSet<OutreachFeedbackOption> OutreachFeedbackOptions { get; set; }
        DbSet<OutreachFeedbackQuestion> OutreachFeedbackQuestions { get; set; }
        DbSet<OutreachFeedbackResponse> OutreachFeedbackResponses { get; set; }
        DbSet<OutreachRole> OutreachRoles { get; set; }
        DbSet<OutreachVolunteer> OutreachVolunteer { get; set; }
        DbSet<Users> Users { get; set; }
        int SaveChanges();
    }
}
