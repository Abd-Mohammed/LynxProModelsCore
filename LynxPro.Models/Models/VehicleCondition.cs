using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class VehicleCondition : TenantAware, ITenantAware
    {
        public int VehicleConditionId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Vehicle Condition Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(7)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Color", Description = "Vehicle Condition Color")]
        public string Color { get; set; }


        [Display(Name = "Is Available", Description = "Is Vehicle Condition Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Is Default", Description = "Is Vehicle Condition Default")]
        public bool IsDefault { get; set; }

        [Range(1, 255)]
        [Display(Name = "Code", Description = "Vehicle Condition Code")]
        public int Code { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Vehicle Condition Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Vehicle Condition Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Vehicle Condition Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Vehicle Condition Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}