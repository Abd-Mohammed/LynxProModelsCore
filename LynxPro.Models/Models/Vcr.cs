using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum VcrType
    {
        [Display(Name = "Pre Trip")]
        PreTrip = 1,
        [Display(Name = "Post Trip")]
        PostTrip = 2
    }

    public enum VcrResult
    {
        [Display(Name = "Safe")]
        Safe = 1,
        [Display(Name = "Partially Safe")]
        PartiallySafe = 2,
        [Display(Name = "Unsafe")]
        Unsafe = 3,
    }

    public class Vcr : TenantAware, ITenantAware
    {
        public Vcr()
        {
            VcrDefects = new HashSet<VcrDefect>();
        }

        public int VcrId { get; set; }

        [Range(1, 2)]
        [Display(Name = "Type", Description = "VCR Type")]
        public VcrType Type { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Location", Description = "VCR Location")]
        public string Location { get; set; }

        [Display(Name = "Odometer (m)", Description = "VCR Odometer (m)")]
        public long Odometer { get; set; }

        [Display(Name = "Engine Hours", Description = "VCR Engine Hours")]
        public double EngineHours { get; set; }

        [Range(1, 3)]
        [Display(Name = "Initial Result", Description = "VCR Initial Result")]
        public VcrResult InitialResult { get; set; }

        [Range(1, 3)]
        [Display(Name = "Final Result", Description = "VCR Final Result")]
        public VcrResult FinalResult { get; set; }

        [Display(Name = "Vehicle", Description = "VCR Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Driver", Description = "VCR Driver Id")]
        public int DriverId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Date", Description = "VCR Date")]
        public DateTime Date { get; set; }

        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "VCR Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "VCR Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [MaxLength(4)]
        [Display(Name = "Passcode", Description = "VCR Passcode")]
        public string Passcode { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Passcode Expired Date", Description = "VCR Passcode Expired Date")]
        public DateTime? PasscodeExpiredDate { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<VcrDefect> VcrDefects { get; set; }
    }
}