
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class AuditSolution : TenantAware, ITenantAware
    {
        public int AuditSolutionId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Ref Id", Description = "Audit Solution Ref Id")]
        public string RefId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Action", Description = "Audit Solution Action")]
        public string Action { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Reason", Description = "Audit Solution Reason")]
        public string Reason { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Audit Solution Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Audit Solution Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}