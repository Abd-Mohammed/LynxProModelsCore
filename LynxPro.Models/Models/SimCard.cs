
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum SimCardStatus
    {
        [Display(Name = "Activated")]
        Activated = 1,
        [Display(Name = "Decativated")]
        Decativated = 2,
    }

    public enum SimCardUsageMode
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Device")]
        Device = 1
    }

    public class SimCard : TenantAware, ITenantAware
    {
        public int SimCardId { get; set; }

        [Required]
        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "MSISDN", Description = "SIM Card MSISDN")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string Msisdn { get; set; }

        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "IMSI", Description = "SIM Card IMSI")]
        [RegularExpression(@"^(?!\-|\+|\@|\*|\=|\\|\/).+", ErrorMessage = "[[[[The]]]] {0} [[[[can not start with invalid character]]]]")]
        public string Imsi { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "ICCID", Description = "SIM Card ICCID")]
        [RegularExpression(@"^(?!\-|\+|\@|\*|\=|\\|\/).+", ErrorMessage = "[[[[The]]]] {0} [[[[can not start with invalid character]]]]")]
        public string Iccid { get; set; }

        [MaxLength(8)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Puk Code", Description = "SIM Card Puk Code")]
        public string PukCode { get; set; }

        [Range(1, 2)]
        [Display(Name = "Status", Description = "SIM Card Status")]
        public SimCardStatus Status { get; set; }

        [Range(0, 1)]
        [Display(Name = "Usage Mode", Description = "SIM Card Usage Mode")]
        public SimCardUsageMode UsageMode { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 1", Description = "SIM Card Custom Attribute 1")]
        public string CustomAttribute1 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 2", Description = "SIM Card Custom Attribute 2")]
        public string CustomAttribute2 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 3", Description = "SIM Card Custom Attribute 3")]
        public string CustomAttribute3 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 4", Description = "SIM Card Custom Attribute 4")]
        public string CustomAttribute4 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 5", Description = "SIM Card Custom Attribute 5")]
        public string CustomAttribute5 { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "SIM Card Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "SIM Card Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "SIM Card Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "SIM Card Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}