
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class PlannedJob : TenantAware, ITenantAware
    {
        public int PlannedJobId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Ref Id", Description = "Planned Job Ref Id")]
        public string RefId { get; set; }

        [Display(Name = "Processing Time (ms)", Description = "Planned Job Processing Time (ms)")]
        public int ProcessingTime { get; set; }

        [Display(Name = "Distance (m)", Description = "Planned Job Distance (m)")]
        public long Distance { get; set; }

        [Display(Name = "Transport Time (sec)", Description = "Planned Job Transport Time (sec)")]
        public long TransportTime { get; set; }

        [Display(Name = "Waiting Time (sec)", Description = "Planned Job Waiting Time (sec)")]
        public long WaitingTime { get; set; }

        [Display(Name = "Completion Time (sec)", Description = "Planned Job Completion Time (sec)")]
        public long CompletionTime { get; set; }

        [DisplayFormat(DataFormatString = StandardDoubleFormats.TwoPlaces)]
        [Display(Name = "Utilization(%)", Description = "Planned Job Utilization(%)")]
        public double Utilization { get; set; }

        [DisplayFormat(DataFormatString = StandardDoubleFormats.TwoPlaces)]
        [Display(Name = "Load Factor(%)", Description = "Planned Job Load Factor(%)")]
        public double LoadFactor { get; set; }

        [Display(Name = "Vehicles No", Description = "Planned Job Vehicles No")]
        public int VehiclesNo { get; set; }

        [Display(Name = "Drivers No", Description = "Planned Job Drivers No")]
        public int DriversNo { get; set; }

        [Display(Name = "People No", Description = "Planned Job People No")]
        public int PeopleNo { get; set; }

        [Display(Name = "Shipments No", Description = "Planned Job Shipments No")]
        public int ShipmentsNo { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Earliest Start Time", Description = "Planned Job Earliest Start Time")]
        public DateTime EarliestStartTime { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Earliest End Time", Description = "Planned Job Earliest End Time")]
        public DateTime EarliestEndTime { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Latest Start Time", Description = "Planned Job Latest Start Time")]
        public DateTime LatestStartTime { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Latest End Time", Description = "Planned Job Latest End Time")]
        public DateTime LatestEndTime { get; set; }

        [Required]
        [Display(Name = "JSON Problem", Description = "Planned Job JSON Problem")]
        public string JsonProblem { get; set; }

        [Required]
        [Display(Name = "JSON Solution", Description = "Planned Job JSON Solution")]
        public string JsonSolution { get; set; }

        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Planned Job Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Planned Job Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}