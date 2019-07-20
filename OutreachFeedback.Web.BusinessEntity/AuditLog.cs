using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutreachFeedback.Web.BusinessEntity
{
    [Serializable]
    public partial class AuditLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AuditID { get; set; }
        public string ModuleName { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string TableKeyID { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
