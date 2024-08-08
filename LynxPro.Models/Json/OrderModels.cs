using Newtonsoft.Json;
using System;

namespace LynxPro.Models.Json
{
    public class ShippingOptions
    {
        [JsonProperty("deliveryOptions", Required = Required.Always)]
        public ShippingDeliveryOptions DeliveryOptions { get; set; }

        [JsonProperty("scheduledDelivery", Required = Required.DisallowNull)]
        public ShippingScheduledDelivery ScheduledDelivery { get; set; }
    }

    public class ShippingDeliveryOptions
    {
        [JsonProperty("deliverAtOnce", Required = Required.Always)]
        public bool DeliverAtOnce { get; set; }

        /// <summary>
        /// Max delivery time in hours
        /// </summary>
        [JsonProperty("maxDeliveryTime", Required = Required.DisallowNull)]
        public int? MaxDeliveryTime { get; set; }

        [JsonProperty("beforeTime", Required = Required.DisallowNull)]
        public TimeSpan? BeforeTime { get; set; }

        [JsonProperty("afterTime", Required = Required.DisallowNull)]
        public TimeSpan? AfterTime { get; set; }
    }

    public class ShippingScheduledDelivery
    {
        [JsonProperty("availableDeliveryDate", Required = Required.Always)]
        public DateTime AvailableDeliveryDate { get; set; }
    }
}