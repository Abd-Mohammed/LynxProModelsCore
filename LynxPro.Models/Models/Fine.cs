
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum FineStatus
    {
        Paid = 1,
        Unpaid = 2
    }

    public class Fine : TenantAware, ITenantAware
    {
        public int FineId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Notice Number", Description = "Fine Notice Number")]
        public string NoticeNumber { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Notice Date", Description = "Fine Notice Date")]
        public DateTime NoticeDate { set; get; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Location", Description = "Fine Location")]
        public string Location { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Issued Date", Description = "Fine Issued Date")]
        public DateTime IssuedDate { set; get; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Due Date", Description = "Fine Due Date")]
        public DateTime? DueDate { set; get; }

        [Range(1, 10000)]
        [Display(Name = "Amount", Description = "Fine Amount")]
        public double Amount { set; get; }

        [MaxLength(250)]
        [Display(Name = "Notes", Description = "Fine Notes")]
        public string Notes { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Payment Date", Description = "Fine Payment Date")]
        public DateTime? PaymentDate { get; set; }

        [Range(1, 2)]
        [Display(Name = "Status", Description = "Fine Status")]
        public FineStatus Status { get; set; }

        [Display(Name = "Fine Type", Description = "Fine Type Id")]
        public int FineTypeId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int? DriverId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Fine Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Fine Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Fine Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Fine Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual FineType FineType { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Driver Driver { get; set; }
    }
}