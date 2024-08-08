
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class FareSchedule : TenantAware, ITenantAware
    {
        public FareSchedule()
        {
            Periods = new HashSet<FareSchedulePeriod>();
        }

        public int FareScheduleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Fare Schedule Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Fare Schedule Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Fare Schedule Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Fare Schedule Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Fare Schedule Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<FareSchedulePeriod> Periods { get; set; }
    }
}