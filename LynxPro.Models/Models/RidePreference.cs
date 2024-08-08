
using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum RidePreferenceType
    {
        [Display(Name = "[[[[Car]]]]")]
        Car = 1,
        [Display(Name = "[[[[Driver]]]]")]
        Driver = 2
    }
    public class RidePreference : TenantAware, ITenantAware
    {
        public int RidePreferenceId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Ride Preference Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Metadata", Description = "Ride Preference Metadata")]
        public string Metadata { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Ride Preference Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Ride Preference Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Ride Preference Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Ride Preference Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public string Id { get { return JsonMapper.Map<RidePreferenceMetadata>(Metadata).Id; } }

        [NotMapped]
        public RidePreferenceType Type { get { return JsonMapper.Map<RidePreferenceMetadata>(Metadata).Type; } }

        [NotMapped]
        public IEnumerable<string> Values { get { return JsonMapper.Map<RidePreferenceMetadata>(Metadata).Values ?? Enumerable.Empty<string>(); } }
    }
}