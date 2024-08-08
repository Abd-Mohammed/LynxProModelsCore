using Newtonsoft.Json;

namespace LynxPro.Models.Json
{
    public class ActRouteDocument
    {
        [JsonProperty("source", Required = Required.Default)]
        public ActRouteSource Source { get; set; }
    }

    public class ActRouteSource
    {
        [JsonProperty("start", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Start { get; set; }

        [JsonProperty("end", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string End { get; set; }

        [JsonProperty("masterRoute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MasterRoute { get; set; }
    }
}
