using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class DriverTransactionData
    {
        [JsonProperty("linkedInvoices", Required = Required.DisallowNull)]
        public IEnumerable<DriverTransactionInvoice> LinkedInvoices { get; set; }

        [JsonProperty("remarks", Required = Required.DisallowNull)]
        public string Remarks { get; set; }
    }

    public class DriverTransactionInvoice
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("number", Required = Required.Always)]
        public string Number { get; set; }

        [JsonProperty("date", Required = Required.Always)]
        public DateTime Date { get; set; }
    }
}