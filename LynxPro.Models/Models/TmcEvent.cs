using System;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum TmcEventType
    {
        [Display(Name = "Accident")]
        Accident = 1,
        [Display(Name = "Closed Road")]
        ClosedRoad = 2,
    }

    public class TmcEvent : TenantAware, ITenantAware
    {
        public int TmcEventId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "TMC Event Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "TMC Event Description")]
        public string Description { get; set; }

        [Display(Name = "Latitude", Description = "TMC Event Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude", Description = "TMC Event Longitude")]
        public double Longitude { get; set; }

        [Display(Name = "Type", Description = "TMC Event Type")]
        [Range(1, 2, ErrorMessage = "The {0} field is required.")]
        public TmcEventType Type { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "TMC Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "TMC Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "TMC Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "TMC Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}