using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum UnitType
    {
        [Display(Name = "Shipment")]
        Shipment = 1,
        [Display(Name = "Service")]
        Service = 2,
        [Display(Name = "Person")]
        Person
    }

    public enum UnitStatus
    {
        [Display(Name = "Unscheduled")]
        Unscheduled = 1,
        [Display(Name = "Enqueued")]
        Enqueued = 2,
        [Display(Name = "Scheduled")]
        Scheduled = 3
    }

    public class Unit : TenantAware, ITenantAware
    {
        public int UnitId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Tracking No", Description = "Unit Tracking No")]
        public string TrackingNo { get; set; }

        [Range(1, 3)]
        [Display(Name = "Type", Description = "Unit Type")]
        public UnitType Type { get; set; }

        [Range(1, 3)]
        [Display(Name = "Status", Description = "Unit Status")]
        public UnitStatus Status { get; set; }

        [Display(Name = "Category", Description = "Unit Category Id")]
        public int? UnitCategoryId { get; set; }

        [Display(Name = "Customer", Description = "Customer Id")]
        public int? CustomerId { get; set; }

        [Required]
        [Display(Name = "Metadata", Description = "Customer Metadata")]
        public string Metadata { get; set; }

        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Unit Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Unit Created Date")]
        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Unit Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Unit Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Last Status Changed Date", Description = "Unit Last Status Changed Date")]
        public DateTime? LastStatusChangedDate { get; set; }

        [Display(Name = "Activity", Description = "Activity Id")]
        public int? ActivityId { get; set; } // in case of unassignment it will be reverted to NULL

        public T GetMetadata<T>() where T : UnitMetadata
        {
            return JsonMapper.Map<T>(Metadata);
        }

        public virtual Customer Customer { get; set; }
        public virtual UnitCategory UnitCategory { get; set; }
        public virtual DirectionsActivity Activity { get; set; }
    }
}