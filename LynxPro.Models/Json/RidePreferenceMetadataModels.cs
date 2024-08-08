using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models.Json
{
    public class RidePreferenceMetadata
    {
        [MaxLength(50)]
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public RidePreferenceType Type { get; set; }

        [JsonProperty("values", Required = Required.DisallowNull)]
        public IEnumerable<string> Values { get; set; }
    }
}
