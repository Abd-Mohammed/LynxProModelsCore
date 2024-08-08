using Newtonsoft.Json;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class VehicleTypeSize
    {
        [JsonProperty("volume", Required = Required.Always)]
        public double Volume { get; set; }

        [JsonProperty("dimensions", Required = Required.DisallowNull)]
        public Dimensions Dimensions { get; set; }

        [JsonProperty("loadSpaces", Required = Required.Always)]
        public IEnumerable<LoadSpace> LoadSpaces { get; set; }
    }

    public class LoadSpace
    {
        [JsonProperty("volume", Required = Required.Always)]
        public double Volume { get; set; }

        [JsonProperty("dimensions", Required = Required.DisallowNull)]
        public Dimensions Dimensions { get; set; }

        [JsonProperty("specifications", Required = Required.Always)]
        public IEnumerable<string> Specifications { get; set; }
    }
}