
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum FareMeterCommandType
    {
        [Display(Name = "Start Meter")]
        StartMeter = 1,
        [Display(Name = "Stop Meter")]
        StopMeter = 2,
        [Display(Name = "Suspend Meter")]
        SuspendMeter = 3,
        [Display(Name = "Restore Meter")]
        RestoreMeter = 4,
        [Display(Name = "End Shift")]
        EndShift = 5,
        [Display(Name = "Retrieve Logs")]
        RetrieveLogs = 6,
        [Display(Name = "Factory Data Reset")]
        FactoryDataReset = 7,
        [Display(Name = "Buzzer")]
        Buzzer = 8
    }

    public enum FareMeterCommandTypeId
    {
        [Display(Name = "Start Meter")]
        C0001 = 1,
        [Display(Name = "Stop Meter")]
        C0002 = 2,
        [Display(Name = "Suspend Meter")]
        C0003 = 3,
        [Display(Name = "Restore Meter")]
        C0004 = 4,
        [Display(Name = "End Shift")]
        C0005 = 5,
        [Display(Name = "Retrieve Logs")]
        RetrieveLogs = 6,
        [Display(Name = "Factory Data Reset")]
        C0007 = 7,
        [Display(Name = "Buzzer")]
        C0006 = 8
    }

    public enum FareMeterCommandStatus
    {
        [Display(Name = "Pending")]
        Pending = 1,
        [Display(Name = "Succeeded")]
        Succeeded = 2,
        [Display(Name = "Meter Engaged")]
        MeterEngaged = 3,
        [Display(Name = "Meter Disengaged")]
        MeterDisengaged = 4,
        [Display(Name = "Active Request")]
        ActiveRequest = 5,
        [Display(Name = "No Available Driver")]
        NoAvailableDriver = 6,
        [Display(Name = "No Available Fare")]
        NoAvailableFare = 7,
        [Display(Name = "Duplicated Command")]
        DuplicatedCommand = 8,
        [Display(Name = "Expired")]
        Expired = 9,
        [Display(Name = "Meter Offline")]
        MeterOffline = 10,
        [Display(Name = "Canceled")]
        Canceled = 11,
        [Display(Name = "Not Allowed")]
        NotAllowed = 12,
        [Display(Name = "Unknown Error")]
        UnknownError = 13,
        [Display(Name = "Meter Busy")]
        MeterBusy = 14
    }

    public class FareMeterCommand : TenantAware, ITenantAware, IFranchiseAware
    {
        public int FareMeterCommandId { get; set; }
        public int FranchiseId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Reference Id", Description = "Fare Meter Reference Id")]
        public string ReferenceId { get; set; }

        [Range(1, 5)]
        [Display(Name = "Type", Description = "Fare Meter Command Type")]
        public FareMeterCommandType Type { get; set; }

        [Range(1, 14)]
        [Display(Name = "Status", Description = "Fare Meter Command Status")]
        public FareMeterCommandStatus Status { get; set; }

        [MaxLength(50)]
        [Display(Name = "Sent By", Description = "Fare Meter Command Sent By")]
        public string SentBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Sent Date", Description = "Fare Meter Command Sent Date")]
        public DateTime SentDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Recieved Date", Description = "Device Message Recieved Date")]
        public DateTime? RecievedDate { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

    }
}