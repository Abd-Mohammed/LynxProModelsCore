using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class DriverInvoiceData
    {
        [JsonProperty("linkedTrips", Required = Required.DisallowNull)]
        public IEnumerable<DriverInvoiceTrip> LinkedTrips { get; set; }

        [JsonProperty("transactions", Required = Required.DisallowNull)]
        public IEnumerable<DriverInvoiceTransaction> Transactions { get; set; }

        [JsonProperty("creditNotes", Required = Required.DisallowNull)]
        public IEnumerable<DriverInvoiceCreditNote> CreditNotes { get; set; }

        [JsonProperty("linkedShifts", Required = Required.DisallowNull)]
        public IEnumerable<DriverInvoiceShift> LinkedShifts { get; set; }

        [JsonProperty("unrecognizedTrips", Required = Required.DisallowNull)]
        public IEnumerable<DriverInvoiceTrip> UnrecognizedTrips { get; set; }
    }

    public class DriverInvoiceTrip
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

        [JsonProperty("vehicle", Required = Required.Always)]
        public DriverInvoiceTripVehicle Vehicle { get; set; }
    }

    public class DriverInvoiceTripVehicle
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }

    public class DriverInvoiceTransaction
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("number", Required = Required.Always)]
        public string Number { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public TransactionType Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("paymentMethod", Required = Required.Always)]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("date", Required = Required.Always)]
        public DateTime Date { get; set; }

        [JsonProperty("amount", Required = Required.Always)]
        public decimal Amount { get; set; }

        [JsonProperty("currencyCode", Required = Required.Always)]
        public string CurrencyCode { get; set; }

        [JsonProperty("settledBy", Required = Required.DisallowNull)]
        public string SettledBy { get; set; }
    }

    public enum DriverInvoiceCreditNoteType
    {
        // Credit Notes are created for the 'unpaid' component of the invoice 
        Adjustment = 1,
        // Credit Notes are created for 'paid' component of the invoice
        Refundable = 2
    }

    public class DriverInvoiceCreditNote
    {
        [JsonProperty("date", Required = Required.Always)]
        public DateTime Date { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public DriverInvoiceCreditNoteType Type { get; set; }

        [JsonProperty("amount", Required = Required.Always)]
        public decimal Amount { get; set; }

        [JsonProperty("currencyCode", Required = Required.Always)]
        public string CurrencyCode { get; set; }
    }

    public class DriverInvoiceShift
    {
        [JsonProperty("shiftId", Required = Required.Always)]
        public int ShiftId { get; set; }

        [JsonProperty("startTime", Required = Required.Always)]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime", Required = Required.Always)]
        public DateTime EndTime { get; set; }
    }
}