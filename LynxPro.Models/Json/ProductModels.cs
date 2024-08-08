using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public enum ProductAttributeDataType
    {
        String = 1,
        Number = 2,
        Boolean = 3,
        Array = 4
    }

    public class ProductTypeAttribute
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("dataType", Required = Required.Always)]
        public ProductAttributeDataType DataType { get; set; }

        [JsonProperty("required", Required = Required.Always)]
        public bool IsRequired { get; set; }

        [JsonProperty("values", Required = Required.DisallowNull)]
        public IEnumerable<string> Values { get; set; }
    }

    public class ProductInfo
    {
        [JsonProperty("weight", Required = Required.Always)]
        public double Weight { get; set; }

        [JsonProperty("size", Required = Required.Always)]
        public ProductInfoSize Size { get; set; }

        [JsonProperty("attributes", Required = Required.Always)]
        public IEnumerable<ProductInfoAttribute> Attributes { get; set; }

        [JsonProperty("specifications", Required = Required.Always)]
        public IEnumerable<string> Specifications { get; set; }
    }

    public class ProductInfoSize
    {
        [JsonProperty("volume", Required = Required.Always)]
        public double Volume { get; set; }

        [JsonProperty("dimensions", Required = Required.DisallowNull)]
        public Dimensions Dimensions { get; set; }
    }

    public class ProductInfoAttribute
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("value", Required = Required.Always)]
        public string Value { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("dataType", Required = Required.Always)]
        public ProductAttributeDataType DataType { get; set; }
    }
}