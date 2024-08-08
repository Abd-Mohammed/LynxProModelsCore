
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TenantArchivingPolicy : TenantAware, ITenantAware
    {
        public int TenantArchivingPolicyId { get; set; }

        [Range(-1, 3)]
        [Display(Name = "Db Retention Period (months)", Description = "Tenant Archiving Policy Db Retention Period (months)")]
        public int DbRetentionPeriod { get; set; }

        [Range(-1, 6)]
        [Display(Name = "Blob Retention Period (months)", Description = "Tenant Archiving Policy Blob Retention Period (months)")]
        public int BlobRetentionPeriod { get; set; }
    }
}