
using LynxPro.Models.Json;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class AlertWorkflow : TenantAware
    {
        public int AlertWorkflowId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public WorkflowType WorkflowType { get; set; }

        [Required]
        public string Document { get; set; }

        [NotMapped]
        public WorkflowInfo WorkflowInfo
        {
            get => string.IsNullOrEmpty(Document) ? null : JsonConvert.DeserializeObject<WorkflowInfo>(Document);
            set => Document = JsonConvert.SerializeObject(value);
        }

        public ICollection<AlertRule> AlertRules { get; set; } = new HashSet<AlertRule>();
    }

    public enum WorkflowType
    {
        [Display(Name = "[[[[Vehicle]]]]")]
        Vehicle = 1,
        [Display(Name = "[[[[Tracked Asset]]]]")]
        TrackedAsset = 2
    }
}