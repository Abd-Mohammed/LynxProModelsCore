
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum ExportTaskType
    {
        Trips = 1,
        [Display(Name = "Shift Invoices")]
        ShiftInvoices = 2,
        [Display(Name = "Closed Alerts")]
        ClosedAlerts = 3,
        Alerts = 4,
    }

    public enum ExportTaskStatus
    {
        Pending = 1,
        InProgress = 2,
        Completed = 3
    }

    public class ExportTask : ITenantAware
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Type of export task
        /// </summary>
        [Display(Name = "Type", Description = "Export Task Type")]
        public ExportTaskType Type { get; set; }

        /// <summary>
        /// Description of the report details
        /// </summary>
        [Required]
        [MaxLength(250)]
        [Display(Name = "Description", Description = "Export Task Description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicates current status
        /// </summary>
        [Display(Name = "Status", Description = "Export Task Status")]
        public ExportTaskStatus Status { get; set; }

        /// <summary>
        /// Indicates current progress in percentage i.e. 0.20
        /// </summary>
        [Display(Name = "Progress", Description = "Export Task Progress")]
        public double Progress { get; set; }

        /// <summary>
        /// Absolute blob URI that can be used directly for download
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "Blob Absolute Uri", Description = "Export Task Blob Absolute Uri")]
        public string BlobAbsoluteUri { get; set; }

        /// <summary>
        /// Username of the user
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Export Task Created By")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Requested time of task
        /// </summary>
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "Tenant Id", Description = "Export Task Tenant Id")]
        public int TenantId { get; set; }
    }
}