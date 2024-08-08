using Newtonsoft.Json;

namespace LynxPro.Models.Json
{
    public class Aqs
    {
        [JsonProperty("ExternalEco2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? ExternalEco2 { get; private set; }

        [JsonProperty("ExternalEtoh", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? ExternalEtoh { get; private set; }

        [JsonProperty("ExternalIaq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? ExternalIaq { get; private set; }

        [JsonProperty("ExternalLogRcda", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? ExternalLogRcda { get; private set; }

        [JsonProperty("ExternalTvoc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? ExternalTvoc { get; private set; }

        [JsonProperty("InternalEco2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? InternalEco2 { get; private set; }

        [JsonProperty("InternalEtoh", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? InternalEtoh { get; private set; }

        [JsonProperty("InternalIaq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? InternalIaq { get; private set; }

        [JsonProperty("InternalLogRcda", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? InternalLogRcda { get; private set; }

        [JsonProperty("InternalTvoc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? InternalTvoc { get; private set; }
    }
}