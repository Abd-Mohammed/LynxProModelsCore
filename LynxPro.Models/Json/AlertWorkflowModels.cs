using Newtonsoft.Json;
using System;

namespace LynxPro.Models.Json
{
    public class WorkflowInfo
    {
        [JsonRequired]
        [JsonProperty("actionsIds")]
        public int[] ActionsIds { get; set; } = Array.Empty<int>();

        [JsonProperty("escalationChainId",
            Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int? EscalationChainId { get; set; }

        [JsonProperty("slaAlertRuleId",
            Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int? SlaAlertRuleId { get; set; }

        [JsonRequired]
        [JsonProperty("emailNotificationIds")]
        public int[] EmailNotificationIds { get; set; } = Array.Empty<int>();

        [JsonRequired]
        [JsonProperty("smsNotificationIds")]
        public int[] SmsNotificationIds { get; set; } = Array.Empty<int>();

        [JsonRequired]
        [JsonProperty("pushNotificationIds")]
        public int[] PushNotificationIds { get; set; } = Array.Empty<int>();

        [JsonRequired]
        [JsonProperty("eventNotificationIds")]
        public int[] EventNotificationIds { get; set; } = Array.Empty<int>();

        [JsonProperty("driverNotificationsEnabled")]
        public bool DriverNotificationsEnabled { get; set; }

        [JsonProperty("aggregatedTimeThreshold",
            Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int? AggregatedTimeThreshold { get; set; }

        [JsonProperty("aggregatedIncidentTimeThreshold",
            Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int? AggregatedIncidentTimeThreshold { get; set; } = 2;

        [JsonProperty("autoClose",
            Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int? AutoClose { get; set; }

        [JsonProperty("acknowledgedAutoClose",
            Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int? AcknowledgedAutoClose { get; set; }

        [JsonProperty("failedActionCountThreshold",
            Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int? FailedActionCountThreshold { get; set; }
    }
}