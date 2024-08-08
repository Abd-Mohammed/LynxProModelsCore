using Newtonsoft.Json;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class Hotspot
    {
        [JsonProperty("sessionTx", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? SessionTx { get; set; }

        [JsonProperty("sessionRx", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? SessionRx { get; set; }

        [JsonProperty("connectedDevices", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? ConnectedDevices { get; set; }

        [JsonProperty("info", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<HotspotInfo> Info { get; set; }

        [JsonProperty("usageTx", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? UsageTx { get; set; }

        [JsonProperty("usage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Usage { get; set; }
    }

    public class HotspotInfo
    {
        [JsonProperty("phone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("mac", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Mac { get; set; }
    }
}