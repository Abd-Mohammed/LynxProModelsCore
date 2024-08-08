using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class VehicleTypeLoad : TenantAware, ITenantAware
    {
        public int VehicleTypeId { get; set; }

        [Range(1, 10000000)]
        [Display(Name = "Max Weight", Description = "Vehicle Type Load Max Weight")]
        public double MaxWeight { get; set; }

        [Required]
        [Display(Name = "Size Document", Description = "Vehicle Type Load Size Document")]
        public string SizeDocument { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Vehicle Type Load Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Vehicle Type Load Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Vehicle Type Load Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Vehicle Type Load Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public VehicleTypeSize Size { get { return JsonMapper.Map<VehicleTypeSize>(SizeDocument); } }

        public virtual VehicleType VehicleType { get; set; }
    }
}