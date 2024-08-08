
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    // TODO: Add Repaired By and Repair Date properties
    public enum DvirType
    {
        [Display(Name = "Pre Trip")]
        PreTrip = 1,
        [Display(Name = "Post Trip")]
        PostTrip = 2
    }

    public enum DriverCertificationResult
    {
        [Display(Name = "Safe")]
        Safe = 1,
        [Display(Name = "Unsafe")]
        Unsafe = 2
    }

    public class Dvir : TenantAware, ITenantAware
    {
        public Dvir()
        {
            DvirDefects = new HashSet<DvirDefect>();
        }

        public int DvirId { get; set; }

        [Range(1, 2)]
        [Display(Name = "Type", Description = "DVIR Type")]
        public DvirType Type { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Location", Description = "DVIR Location")]
        public string Location { get; set; }

        [Display(Name = "Odometer (m)", Description = "DVIR Odometer (m)")]
        public long Odometer { get; set; }

        [MaxLength(100)]
        [Display(Name = "Remark", Description = "Certification Remark")]
        public string CertificationRemark { get; set; }

        [Display(Name = "Result", Description = "Certification Result")]
        public DriverCertificationResult CertificationResult { get; set; }

        [Display(Name = "Vehicle", Description = "DVIR Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Trailer", Description = "DVIR Trailer Id")]
        public int? TrailerId { get; set; }

        [Display(Name = "Inspected By", Description = "DVIR Inspected By Id")]
        public int InspectedById { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Inspection Date", Description = "DVIR Inspection Date")]
        public DateTime InspectionDate { get; set; }

        public virtual Driver InspectedBy { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Trailer Trailer { get; set; }
        public virtual ICollection<DvirDefect> DvirDefects { get; set; }
    }
}