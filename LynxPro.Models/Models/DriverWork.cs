
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class DriverWork : TenantAware, ITenantAware
    {
        public int DriverWorkId { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name = "Name", Description = "Driver Work Name")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time", Description = "Driver Work Start Time")]
        public TimeSpan StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time", Description = "Driver Work End Time")]
        public TimeSpan EndTime { get; set; }

        [Required]
        [MaxLength(7)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Color", Description = "Driver Work Color")]
        public string Color { get; set; }

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