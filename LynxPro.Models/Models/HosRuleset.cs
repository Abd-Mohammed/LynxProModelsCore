
using System;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class HosRuleset : TenantAware, ITenantAware
    {
        public int HosRulesetId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Ruleset Name")]
        public string Name { get; set; }

        [Range(1, 100)]
        [Display(Name = "Cycle (h)", Description = "Ruleset Cycle (h)")]
        public int Cycle { get; set; }

        [Range(7, 8)]
        [Display(Name = "DaysNo", Description = "Ruleset Name")]
        public int DaysNo { get; set; }

        [Range(1, 100)]
        [Display(Name = "Cycle OFF/SB (h)", Description = "Ruleset Cycle OFF/SB (h)")]
        public int CycleOffOrSb { get; set; }

        [Range(1, 100)]
        [Display(Name = "Duty (h)", Description = "Ruleset Name (h)")]
        public int Duty { get; set; }

        [Range(1, 100)]
        [Display(Name = "Duty OFF/SB (h)", Description = "Ruleset Duty OFF/SB (h)")]
        public int DutyOffOrSb { get; set; }

        [Range(1, 120)]
        [Display(Name = "Driving (h)", Description = "Ruleset Driving (h)")]
        public int Driving { get; set; }

        [Range(1, 100)]
        [Display(Name = "Consecutive Driving (h)", Description = "Ruleset Consecutive Driving (h)")]
        public int ConsecutiveDriving { get; set; }

        [Range(1, 120)]
        [Display(Name = "Rest (min)", Description = "Ruleset Rest (min)")]
        public int Rest { get; set; }

        [Display(Name = "Is Enabled", Description = "Is Ruleset Enabled")]
        public bool IsEnabled { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Driver Work Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Driver Work Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Driver Work Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Driver Work Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}