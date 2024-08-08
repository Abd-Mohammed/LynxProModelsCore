using Newtonsoft.Json;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class ShiftSummary
    {
        public ShiftSummary()
        {
            StartLocation = new ShiftLocation()
            {
                Address = "n/a",
                Latitude = 0,
                Longitude = 0
            };

            EndLocation = new ShiftLocation()
            {
                Address = "n/a",
                Latitude = 0,
                Longitude = 0
            };
        }

        [JsonProperty("startLocation", Required = Required.Always)]
        public ShiftLocation StartLocation { get; set; }

        [JsonProperty("endLocation", Required = Required.Always)]
        public ShiftLocation EndLocation { get; set; }

        [JsonProperty("startOdometer", Required = Required.DisallowNull)]
        public long StartOdometer { get; set; }

        [JsonProperty("endOdometer", Required = Required.DisallowNull)]
        public long EndOdometer { get; set; }

        [JsonProperty("distance", Required = Required.Always)]
        public long Distance { get; set; }

        [JsonProperty("startShiftAreas", Required = Required.DisallowNull)]
        public IEnumerable<ShiftAreas> StartShiftAreas { get; set; }

        [JsonProperty("endShiftAreas", Required = Required.DisallowNull)]
        public IEnumerable<ShiftAreas> EndShiftAreas { get; set; }
    }

    public class ShiftLocation
    {
        [JsonProperty("address", Required = Required.Always)]
        public string Address { get; set; }

        [JsonProperty("latitude", Required = Required.Always)]
        public double Latitude { get; set; }

        [JsonProperty("longitude", Required = Required.Always)]
        public double Longitude { get; set; }
    }

    public class ShiftAreas
    {
        [JsonProperty("name", Required = Required.DisallowNull)]
        public string Name { get; set; }
    }
}
