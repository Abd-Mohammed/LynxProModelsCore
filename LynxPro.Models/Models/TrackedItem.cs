using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TrackedItem : TenantAware, ITenantAware
    {
        public int TrackedItemId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Tracked Asset Name")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Display(Name = "Owner Name", Description = "Tracked Asset Owner Name")]
        public string OwnerName { get; set; }

        [MaxLength(20)]
        [Display(Name = "Owner Phone", Description = "Owner Phone No")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string OwnerPhoneNo { get; set; }

        [Display(Name = "Tracked Asset Type", Description = "Tracked Asset Type Id")]
        public int TrackedItemTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Tracked Asset Group Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Tracked Asset Group Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Tracked Asset Group Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Tracked Asset Group Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Device", Description = "Device Id")]
        public int? DeviceId { get; set; }

        [JsonIgnore]
        public virtual TrackedItemType TrackedItemType { get; set; }
        [JsonIgnore]
        public virtual Device Device { get; set; }
        [JsonIgnore]
        public virtual TrackedItemState TrackedItemState { get; set; }
    }
}