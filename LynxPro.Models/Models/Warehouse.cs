using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class Warehouse : TenantAware, ITenantAware
    {
        public int WarehouseId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Warehouse Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Address", Description = "Warehouse Address")]
        public string Address { get; set; }

        [MaxLength(100)]
        [Display(Name = "Contact Name", Description = "Warehouse Contact Name")]
        public string ContactName { get; set; }

        [MaxLength(20)]
        [Display(Name = "Contact Number", Description = "Warehouse Contact Number")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Settings Document", Description = "Warehouse Settings Document")]
        public string SettingsDocument { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Warehouse Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Warehouse Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Warehouse Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Warehouse Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public WarehouseSettings Settings { get { return JsonMapper.Map<WarehouseSettings>(SettingsDocument); } }
    }
}