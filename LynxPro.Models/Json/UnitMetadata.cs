using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class UnitMetadata
    {
        [JsonProperty("zone", Required = Required.DisallowNull)]
        public string Zone { get; set; }
    }

    public class ShipmentUnitMetadata : UnitMetadata
    {
        // Pickup Info
        [JsonProperty("pickupAddress", Required = Required.Always)]
        public string PickupAddress { get; set; }

        [JsonProperty("pickupLatitude", Required = Required.Always)]
        public double PickupLatitude { get; set; }

        [JsonProperty("pickupLongitude", Required = Required.Always)]
        public double PickupLongitude { get; set; }

        [JsonProperty("pickupDuration", Required = Required.Always)]
        public int PickupDuration { get; set; }

        [JsonProperty("pickupReadyTime", Required = Required.DisallowNull)]
        public TimeSpan? PickupReadyTime { get; set; }

        // Delivery Info
        [JsonProperty("deliveryAddress", Required = Required.Always)]
        public string DeliveryAddress { get; set; }

        [JsonProperty("deliveryLatitude", Required = Required.Always)]
        public double DeliveryLatitude { get; set; }

        [JsonProperty("deliveryLongitude", Required = Required.Always)]
        public double DeliveryLongitude { get; set; }

        [JsonProperty("deliveryDuration", Required = Required.Always)]
        public int DeliveryDuration { get; set; }

        [JsonProperty("deliveryReadyTime", Required = Required.DisallowNull)]
        public TimeSpan? DeliveryReadyTime { get; set; }

        [JsonProperty("deliveryDueTime", Required = Required.DisallowNull)]
        public TimeSpan? DeliveryDueTime { get; set; }

        // Demands
        [JsonProperty("weightDemand", Required = Required.DisallowNull)]
        public long? WeightDemand { get; set; } = 1;

        [JsonProperty("volumeDemand", Required = Required.DisallowNull)]
        public long? VolumeDemand { get; set; } = 1;

        [JsonProperty("items", Required = Required.DisallowNull)]
        public List<ShipmentItem> Items { get; set; }

        [JsonProperty("attributes", Required = Required.DisallowNull)]
        public List<UnitAttribute> Attributes { get; set; }
    }

    public class ShipmentItem
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("quantity", Required = Required.Always)]
        public int Quantity { get; set; }
    }

    public class UnitAttribute
    {
        [JsonProperty("key", Required = Required.AllowNull)]
        public string Key { get; set; }

        [JsonProperty("value", Required = Required.AllowNull)]
        public string Value { get; set; }
    }

    public class UnitCategoryAttribute
    {
        [JsonProperty("name", Required = Required.AllowNull)]
        public string Name { get; set; }

        [JsonProperty("type", Required = Required.AllowNull)]
        public string Type { get; set; }

        [JsonProperty("required", Required = Required.AllowNull)]
        public bool IsRequired { get; set; }
    }
}
