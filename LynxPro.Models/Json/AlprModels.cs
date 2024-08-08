using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace LynxPro.Models.Json
{
    public enum AlprColorType
    {
        Unknown = 0,
        Black = 1,
        Blue = 2,
        Brown = 3,
        Green = 4,
        Red = 5,
        Silver = 6,
        White = 7,
        Yellow = 8
    }

    public enum AlprVehicleType
    {
        Unknown = 0,
        BigTruck = 1,
        Bus = 2,
        Motorcycle = 3,
        PickupTruck = 4,
        Sedan = 5,
        Suv = 6,
        Van = 7
    }

    public enum AlprOrientationType
    {
        Unknown = 0,
        Front = 1,
        Rear = 2
    }
    [Serializable]
    public class Alpr
    {
        [JsonProperty("plate", Required = Required.DisallowNull)]
        public string Plate { get; set; }

        [JsonProperty("confidence", Required = Required.DisallowNull)]
        public double? Confidence { get; set; }

        [JsonProperty("vehicle", Required = Required.DisallowNull)]
        public AlprVehicle Vehicle { get; set; }

        [JsonProperty("modelMake", Required = Required.DisallowNull)]
        public AlprModelMake ModelMake { get; set; }

        [JsonProperty("color", Required = Required.DisallowNull)]
        public AlprColor Color { get; set; }

        [JsonProperty("orientation", Required = Required.DisallowNull)]
        public AlprOrientation Orientation { get; set; }
    }

    public class AlprVehicle
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public AlprVehicleType Type { get; set; }

        [JsonProperty("confidence", Required = Required.DisallowNull)]
        public double? Confidence { get; set; }
    }

    public class AlprModelMake
    {
        [JsonProperty("make", Required = Required.Always)]
        public string Make { get; set; }

        [JsonProperty("model", Required = Required.Always)]
        public string Model { get; set; }

        [JsonProperty("confidence", Required = Required.DisallowNull)]
        public double? Confidence { get; set; }
    }

    public class AlprColor
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("color", Required = Required.Always)]
        public AlprColorType Color { get; set; }

        [JsonProperty("confidence", Required = Required.DisallowNull)]
        public double? Confidence { get; set; }
    }

    public class AlprOrientation
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("orientation", Required = Required.Always)]
        public AlprVehicleType Orientation { get; set; }

        [JsonProperty("confidence", Required = Required.DisallowNull)]
        public double? Confidence { get; set; }
    }
}