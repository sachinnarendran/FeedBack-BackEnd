using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutreachFeedback.Web.BusinessEntity
{
    [Serializable]
    public partial class ErrorLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ErrorID { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime? ErrorDate { get; set; }
    }
}
