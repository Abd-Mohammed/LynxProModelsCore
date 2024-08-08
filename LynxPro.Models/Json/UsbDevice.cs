using Newtonsoft.Json;

namespace LynxPro.Models.Json
{
    public class UsbDevice
    {
        [JsonProperty("status", Required = Required.Always)]
        public bool Status { get; set; }

        [JsonProperty("deviceName", Required = Required.Always)]
        public string DeviceName { get; set; }

        [JsonProperty("manufacturerName", Required = Required.Always)]
        public string ManufacturerName { get; set; }

        [JsonProperty("productId", Required = Required.Always)]
        public int ProductId { get; set; }

        [JsonProperty("productName", Required = Required.Always)]
        public string ProductName { get; set; }

        [JsonProperty("vendorId", Required = Required.Always)]
        public int VendorId { get; set; }

        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }
    }
}
