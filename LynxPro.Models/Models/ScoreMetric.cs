
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class ScoreMetric : TenantAware, ITenantAware
    {
        public int ScoreMetricId { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Score", Description = "Score Metric Limit")]
        public int Limit { get; set; }

        [Range(0.01, 1.0)]
        [Display(Name = "Weight", Description = "Score Metric Weight")]
        public double Weight { get; set; }

        [Display(Name = "Cost Implication", Description = "Score Metric Cost Implication")]
        public decimal CostImplication { get; set; }

        [Required]
        [MaxLength(7)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Color", Description = "Score Metric Color")]
        public string Color { get; set; }

        [Display(Name = "Alert Rule", Description = "Alert Rule Id")]
        public int AlertRuleId { get; set; }

        [Display(Name = "Score Card", Description = "Score Card Id")]
        public int ScoreCardId { get; set; }

        public virtual AlertRule AlertRule { get; set; }
        public virtual ScoreCard ScoreCard { get; set; }
    }
}