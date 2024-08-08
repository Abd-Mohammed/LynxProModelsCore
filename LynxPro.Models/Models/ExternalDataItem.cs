
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class ExternalDataItem : TenantAware, ITenantAware
    {
        public int ExternalDataItemId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "External Data Item Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Number", Description = "Number")]
        public string Number { get; set; }

        [Display(Name = "External Data Type", Description = "External Data Type Id")]
        public int ExternalDataTypeId { get; set; }

        public virtual ExternalDataType ExternalDataType { get; set; }
    }
}