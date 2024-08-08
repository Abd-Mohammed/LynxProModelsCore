using Newtonsoft.Json;

namespace LynxPro.Models.Json
{
    public class RideRequestOptions
    {
        [JsonProperty("maxArrivalDuration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxArrivalDuration { get; set; }

        [JsonProperty("requiredDriverStaffId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string RequiredDriverStaffId { get; set; }

        [JsonProperty("tryOnce", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool TryOnce { get; set; }
    }
}
