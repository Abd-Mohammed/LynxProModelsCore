
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class AreaItem : TenantAware, ITenantAware
    {
        [Display(Name = "Area Group", Description = "Area Group Id")]
        public int AreaGroupId { get; set; }

        [Display(Name = "Area", Description = "Area Id")]
        public int AreaId { get; set; }

        public virtual AreaGroup AreaGroup { get; set; }
        public virtual Area Area { get; set; }
    }
}