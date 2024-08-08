using Newtonsoft.Json;

namespace LynxPro.Models.Json
{
    public class Dsm
    {
        [JsonProperty("alertId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? AlertId { get; set; }

        [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Status { get; set; }

        [JsonProperty("faceDetected", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? FaceDetected { get; set; }
    }
}
