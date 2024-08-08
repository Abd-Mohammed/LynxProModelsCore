using Newtonsoft.Json;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class DriverBalanceDetails
    {
        [JsonProperty("unbilledTripCharges", Required = Required.DisallowNull)]
        public IEnumerable<DriverUnbilledTripCharge> UnbilledTripCharges { get; set; }
    }

    public class DriverUnbilledTripCharge
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("code", Required = Required.Always)]
        public string Code { get; set; }

        [JsonProperty("netFare", Required = Required.Always)]
        public decimal NetFare { get; set; }

        [JsonProperty("totalFare", Required = Required.Always)]
        public decimal TotalFare { get; set; }

        [JsonProperty("fareCurrencyCode", Required = Required.Always)]
        public string FareCurrencyCode { get; set; }
    }
}