using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class TollOptions
    {
        [JsonProperty("group", Required = Required.DisallowNull)]
        public TollGroup Group { get; set; }

        [JsonProperty("timings", Required = Required.Always)]
        public IEnumerable<TollTiming> Timings { get; set; }
    }

    public class TollGroup
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("cooldown", Required = Required.Always)]
        public int Cooldown { get; set; }
    }

    public class TollTiming
    {
        [JsonProperty("days", Required = Required.Always)]
        public string[] Days { get; set; }

        [JsonProperty("from", Required = Required.Always)]
        public TimeSpan From { get; set; }

        [JsonProperty("to", Required = Required.Always)]
        public TimeSpan To { get; set; }
    }
}