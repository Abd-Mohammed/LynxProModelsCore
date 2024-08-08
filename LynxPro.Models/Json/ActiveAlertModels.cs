using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LynxPro.Models.Json
{
    public enum JsonAlertSla
    {
        None = 0,
        Breached = 1,
        NotBreached = 2
    }

    public class JsonAlert
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("openDate", Required = Required.Always)]
        public DateTime OpenDate { get; set; }

        [JsonProperty("lastDate", Required = Required.Always)]
        public DateTime LastDate { get; set; }

        [JsonProperty("duration", Required = Required.Always)]
        public long Duration { get; set; }

        [JsonProperty("incidentCount", Required = Required.Always)]
        public int IncidentCount { get; set; }

        [JsonProperty("hasEvidence", Required = Required.Always)]
        public bool HasEvidence { get; set; }

        [JsonProperty("violation", Required = Required.Always)]
        public bool IsViolation { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("sla", Required = Required.Always)]
        public JsonAlertSla Sla { get; set; }

        [JsonProperty("driverStaffId", Required = Required.DisallowNull)]
        public string DriverStaffId { get; set; }

        [JsonProperty("resolutionStateId", Required = Required.Always)]
        public int ResolutionStateId { get; set; }

        [JsonProperty("alertRuleId", Required = Required.Always)]
        public int AlertRuleId { get; set; }
    }
}