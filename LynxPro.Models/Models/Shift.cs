using LynxPro.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class Shift : TenantAware, ITenantAware
    {
        public int ShiftId { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name = "Name", Description = "Shift Name")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time", Description = "Shift Start Time")]
        public TimeSpan StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time", Description = "Shift End Time")]
        public TimeSpan EndTime { get; set; }

        [Range(0, 120)]
        [Display(Name = "Break Time (min)", Description = "Shift Break Time (min)")]
        public int BreakTime { get; set; }

        [Range(0, 60)]
        [Display(Name = "Grace Period (min)", Description = "Shift Grace Period (min)")]
        public int GracePeriod { get; set; }

        [Required]
        [MaxLength(7)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Color", Description = "Shift Color")]
        public string Color { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Shift Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Shift Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Shift Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Shift Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}