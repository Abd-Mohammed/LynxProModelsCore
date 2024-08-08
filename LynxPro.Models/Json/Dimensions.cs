using Newtonsoft.Json;

namespace LynxPro.Models.Json
{
    public class Dimensions
    {
        [JsonProperty("length", Required = Required.Always)]
        public double Length { get; set; }

        [JsonProperty("width", Required = Required.Always)]
        public double Width { get; set; }

        [JsonProperty("height", Required = Required.Always)]
        public double Height { get; set; }
    }
}