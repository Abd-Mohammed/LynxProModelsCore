
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DeviceHealthAlertRule : TenantAware, ITenantAware
    {
        [Display(Name = "Device Health", Description = "Device Health Id")]
        public int DeviceHealthId { get; set; }

        [Display(Name = "Alert Rule", Description = "Alert Rule Id")]
        public int AlertRuleId { get; set; }

        public virtual DeviceHealth DeviceHealth { get; set; }
        public virtual AlertRule AlertRule { get; set; }
    }
}