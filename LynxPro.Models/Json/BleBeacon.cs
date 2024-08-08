using Newtonsoft.Json;

namespace LynxPro.Models.Json
{
    public class BleBeacon
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rssi")]
        public int Rssi { get; set; }
    }
}