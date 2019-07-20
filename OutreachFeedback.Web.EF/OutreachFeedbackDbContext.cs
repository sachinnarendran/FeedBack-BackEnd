using Microsoft.EntityFrameworkCore;
using OutreachFeedback.Web.BusinessEntity;

namespace OutreachFeedback.Web.EF
{
    public class OutreachFeedbackDbContext : DbContext, IOutreachFeedbackDbContext
    {
        public OutreachFeedbackDbContext(DbContextOptions<OutreachFeedbackDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutreachEventInformation>()
            .HasKey(c => new { c.EventID, c.EmployeeID,c.EventName });            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<OutreachEventInformation> OutreachEventInformation { get; set; }
        public DbSet<OutreachEventSummary> OutreachEventSummary { get; set; }
        public DbSet<OutreachFeedbackOption> OutreachFeedbackOptions { get; set; }
        public DbSet<OutreachFeedbackQuestion> OutreachFeedbackQuestions { get; set; }
        public DbSet<OutreachFeedbackResponse> OutreachFeedbackResponses { get; set; }
        public DbSet<OutreachRole> OutreachRoles { get; set; }
        public DbSet<OutreachVolunteer> OutreachVolunteer { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
