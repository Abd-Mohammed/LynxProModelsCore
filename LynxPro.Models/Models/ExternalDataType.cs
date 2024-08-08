
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class ExternalDataType : TenantAware, ITenantAware
    {
        public ExternalDataType()
        {
            ExternalDataItems = new HashSet<ExternalDataItem>();
        }

        public int ExternalDataTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "External Data Type Name")]
        public string Name { get; set; }

        public virtual ICollection<ExternalDataItem> ExternalDataItems { get; set; }
    }
}