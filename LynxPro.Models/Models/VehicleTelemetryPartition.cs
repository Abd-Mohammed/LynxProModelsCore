using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public abstract class VehicleTelemetryPartition : TenantAware, ITenantAware
    {
        private TelemetryPayload telemetryPayload;

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Timestamp", Description = "Telemetry Timestamp")]
        public DateTime Timestamp { get; set; }

        [Required]
        [MaxLength(2500)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Payload", Description = "Telemetry Payload")]
        public string PayloadDocument { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Server Timestamp", Description = "Telemetry Timestamp")]
        public DateTime ServerTimestamp { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        public long VehicleTelemetryId { get; set; }

        [NotMapped]
        public TelemetryPayload Payload
        {
            get
            {
                if (telemetryPayload == null)
                {
                    telemetryPayload = JsonMapper.MapOrDefault<TelemetryPayload>(PayloadDocument);
                    return telemetryPayload;
                }
                else
                {
                    return telemetryPayload;
                }
            }
            set
            {
                telemetryPayload = value;
            }
        }

        public virtual Vehicle Vehicle { get; set; }
        public static VehicleTelemetryPartition Create(DateTime partition)
        {
            string month = GetMonth(partition);
            switch (month)
            {
                case "01":
                    return new VehicleTelemetryPartition01();
                case "02":
                    return new VehicleTelemetryPartition02();
                case "03":
                    return new VehicleTelemetryPartition03();
                case "04":
                    return new VehicleTelemetryPartition04();
                case "05":
                    return new VehicleTelemetryPartition05();
                case "06":
                    return new VehicleTelemetryPartition06();
                case "07":
                    return new VehicleTelemetryPartition07();
                case "08":
                    return new VehicleTelemetryPartition08();
                case "09":
                    return new VehicleTelemetryPartition09();
                case "10":
                    return new VehicleTelemetryPartition10();
                case "11":
                    return new VehicleTelemetryPartition11();
                case "12":
                    return new VehicleTelemetryPartition12();
                default:
                    return null;
            }
        }

        public static string GetMonth(DateTime date)
        {
            var monthValue = date.Month;
            string monthAsString = monthValue < 10 ? "0" + monthValue : monthValue.ToString();
            return monthAsString;
        }
    }
}