using LynxPro.Models.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum SubscriptionStatus
    {
        [Display(Name = "[[[[Active]]]]")]
        Active = 1,
    }

    public enum SubscriptionAddonStatus
    {
        [Display(Name = "[[[[Active]]]]")]
        Active = 1
    }

    public class Subscription : TenantAware, ITenantAware
    {
        public int SubscriptionId { get; set; }

        public string Json { get; set; }

        [NotMapped]
        public SubscriptionJson SubscriptionJson { get { return JsonMapper.MapOrDefault<SubscriptionJson>(Json); } }
    }

    public class SubscriptionJson
    {
        [JsonProperty("id", Required = Required.Always)]
        public Guid Id { get; set; }

        [JsonProperty("organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }

        [JsonProperty("currencyCode", Required = Required.Always)]
        public string CurrencyCode { get; set; }

        [JsonProperty("planId", NullValueHandling = NullValueHandling.Ignore, Required = Required.DisallowNull)]
        public string PlanId { get; set; }

        [JsonProperty("currentTermEnd", Required = Required.Always)]
        public DateTime CurrentTermEnd { get; set; }

        [JsonProperty("currentTermStart", Required = Required.Always)]
        public DateTime CurrentTermStart { get; set; }

        [JsonProperty("startedAt", Required = Required.Always)]
        public DateTime StartedAt { get; set; }

        [JsonProperty("createdAt", Required = Required.Always)]
        public DateTime CreatedAt { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("status", Required = Required.Always)]
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Active;

        [JsonProperty("addons", Required = Required.Always)]
        public IEnumerable<SubscriptionAddon> Addons { get; set; }
    }

    public class SubscriptionAddon
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("status", Required = Required.Always)]
        public SubscriptionAddonStatus Status { get; set; }
    }
}
