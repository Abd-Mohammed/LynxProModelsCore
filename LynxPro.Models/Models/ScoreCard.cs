
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class ScoreCard : TenantAware, ITenantAware
    {
        public ScoreCard()
        {
            ScoreMetrics = new HashSet<ScoreMetric>();
        }

        public int ScoreCardId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Score Card", Description = "Score Card Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Score Card Description")]
        public string Description { get; set; }

        public virtual ICollection<ScoreMetric> ScoreMetrics { get; set; }
    }
}