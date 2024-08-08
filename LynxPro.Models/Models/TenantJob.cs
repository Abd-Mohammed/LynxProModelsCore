using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TenantJob : TenantAware, ITenantAware
    {
        public int TenantJobId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Cron Id", Description = "Tenant Job Cron Id")]
        public string CronId { get; set; }

        [Required]
        [Display(Name = "Invocation Data", Description = "Tenant Job Invocation Data")]
        public string InvocationData { get; set; }
    }
}