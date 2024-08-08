using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum FalseAlert
    {
        [Display(Name = "Yes")]
        Yes = 1,
        [Display(Name = "No")]
        No = 0
    }
    public enum SeverityLevel
    {
        [Display(Name = "Critical")]
        Critical = 1,
        [Display(Name = "Warning")]
        Warning = 2,
        [Display(Name = "Information")]
        Information = 3,
    }

    [Flags]
    public enum DaysOfWeek
    {
        [Display(Name = "Monday")]
        Monday = 1,
        [Display(Name = "Tuesday")]
        Tuesday = 2,
        [Display(Name = "Wednesday")]
        Wednesday = 4,
        [Display(Name = "Thursday")]
        Thursday = 8,
        [Display(Name = "Friday")]
        Friday = 16,
        [Display(Name = "Saturday")]
        Saturday = 32,
        [Display(Name = "Sunday")]
        Sunday = 64,
    }

    public enum RecurringDay
    {
        [Display(Name = "On")]
        On = 1,
        [Display(Name = "Not On")]
        NotOn = 2,
    }

    public enum RecurringTime
    {
        [Display(Name = "Between")]
        Between = 1,
        [Display(Name = "Outside")]
        Outside = 2,
    }

    public enum AlertPermissionType
    {
        App = 1,
        Role = 2
    }

    public class AlertPermission
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AlertPermissionType Type { get; set; }
    }

    public class AlertRule : TenantAware, ITenantAware
    {
        public AlertRule()
        {
            AlertRuleActions = new HashSet<AlertRuleAction>();
            AlertRuleNotificationRules = new HashSet<AlertRuleNotificationRule>();
            AlertRulePeriods = new HashSet<AlertRulePeriod>();
            AlertRuleTags = new HashSet<AlertRuleTag>();
        }

        public int AlertRuleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Alert Rule Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Description", Description = "Alert Rule Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Expression", Description = "Alert Rule Expression")]
        public string Expression { get; set; }

        [Display(Name = "Severity", Description = "Alert Rule Severity")]
        public SeverityLevel Severity { get; set; }

        [Display(Name = "Is Enabled", Description = "Is Alert Rule Enabled ")]
        public bool IsEnabled { get; set; }

        [Display(Name = "Vehicle Group", Description = "Vehicle Group Id")]
        public int? VehicleGroupId { get; set; }

        [Display(Name = "Tracked Asset Group", Description = "Tracked Asset Group Id")]
        public int? TrackedItemGroupId { get; set; }

        [Display(Name = "Recurring Day", Description = "Alert Rule Recurring Day")]
        public RecurringDay? RecurringDay { get; set; }

        [Display(Name = "Days of Week", Description = "Alert Rule Days of Week")]
        public DaysOfWeek? DaysOfWeek { get; set; }

        [Display(Name = "Recurring Time", Description = "Alert Rule Recurring Time")]
        public RecurringTime? RecurringTime { get; set; }

        [Display(Name = "From Time", Description = "Alert Rule From Time")]
        public TimeSpan? FromTime { get; set; }

        [Display(Name = "To Time", Description = "Alert Rule To Time")]
        public TimeSpan? ToTime { get; set; }

        [Display(Name = "Is Event Notification Enabled", Description = "Is Alert Rule Event Notification Enabled")]
        public bool IsEventNotificationEnabled { get; set; }

        [Display(Name = "Is Email Notification Enabled", Description = "Is Alert Rule Email Notification Enabled")]
        public bool IsEmailNotificationEnabled { get; set; }

        [Display(Name = "Is SMS Notification Enabled", Description = "Is Alert Rule SMS Notification Enabled")]
        public bool IsSmsNotificationEnabled { get; set; }

        [Display(Name = "Is Push Notification Enabled", Description = "Is Push Notification Enabled")]
        public bool IsPushNotificationEnabled { get; set; }

        [Display(Name = "Is Driver Notification Enabled", Description = "Is Driver Notification Enabled")]
        public bool IsDriverNotificationEnabled { get; set; }

        [Range(1, 11519)]
        [Display(Name = "Auto Close (min)", Description = "Alert Rule Auto Close (min)")]
        public int? AutoClose { get; set; }

        [Range(60, 4320)]
        [Display(Name = "Acknowledged Auto Close (min)", Description = "Alert Rule Acknowledged Auto Close (min)")]
        public int? AcknowledgedAutoClose { get; set; }

        [Range(1, 10)]
        [Display(Name = "Failed Action Count Threshold", Description = "Alert Rule Failed Action Count Threshold")]
        public int? FailedActionCountThreshold { get; set; }

        [Display(Name = "Escalation Chain", Description = "Escalation Chain Id")]
        public int? EscalationChainId { get; set; }

        [Display(Name = "SLA Alert Rule", Description = "SLA Alert Rule Id")]
        public int? SlaAlertRuleId { get; set; }

        [Display(Name = "Workflow", Description = "Workflow")]
        public int? AlertWorkflowId { get; set; }

        [Display(Name = "Is Locked", Description = "Is Alert Rule Locked")]
        public bool IsLocked { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Alert Rule Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Alert Rule Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Alert Rule Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Alert Rule Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Is Bookmarked", Description = "Is Alert Rule Bookmarked")]
        public bool IsBookmarked { get; set; }

        [Range(1, 1440)]
        [Display(Name = "Aggregated Time Threshold (min)", Description = "Alert Aggregated Time Threshold (min)")]
        public int? AggregatedTimeThreshold { get; set; }

        [Range(1, 1440)]
        [Display(Name = "Aggregated Incident Time Thershold (min)", Description = "Alert Aggregated Incident Time Thershold (min)")]
        public int? AggregatedIncidentTimeThreshold { get; set; }

        [Display(Name = "Is Violation", Description = "Is Violation Alert Rule")]
        public bool IsViolation { get; set; }

        public bool Restricted()
        {
            var json = JObject.Parse(Expression);
            if (json["permissions"] == null)
            {
                return false;
            }

            var permissions = ParsePermissions(json["permissions"]);
            return permissions.Count() > 0;
        }

        public bool HasPermission(params string[] names)
        {
            var json = JObject.Parse(Expression);
            if (json["permissions"] == null)
            {
                return true;
            }

            var permissions = ParsePermissions(json["permissions"]);
            return permissions.Any(p => names.Contains(p.Name));
        }

        public void AddPermissions(params string[] names)
        {
            var list = new List<AlertPermission>();
            foreach (var name in names)
            {
                list.Add(new AlertPermission()
                {
                    Name = name,
                    Type = AlertPermissionType.Role
                });
            }

            var json = JObject.Parse(Expression);
            json["permissions"] = JArray.FromObject(list);
            Expression = json.ToString(Formatting.None);
        }

        public void ReplacePermission(string oldName, string newName)
        {
            var json = JObject.Parse(Expression);
            if (json["permissions"] == null)
            {
                return;
            }

            var permissions = ParsePermissions(json["permissions"]).ToList();
            for (int i = 0; i < permissions.Count; i++)
            {
                if (permissions[i].Name.Equals(oldName, StringComparison.OrdinalIgnoreCase))
                {
                    permissions[i].Name = newName;
                }
            }

            json["permissions"] = JArray.FromObject(permissions);
            Expression = json.ToString(Formatting.None);
        }

        public void RemovePermission(string name)
        {
            var json = JObject.Parse(Expression);
            if (json["permissions"] == null)
            {
                return;
            }

            var permissions = ParsePermissions(json["permissions"]).ToList();
            for (int i = 0; i < permissions.Count; i++)
            {
                if (permissions[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    permissions.RemoveAt(i);
                }
            }

            if (permissions.Count > 0)
            {
                json["permissions"] = JArray.FromObject(permissions);
            }
            else
            {
                json.Remove("permissions");
            }

            Expression = json.ToString(Formatting.None);
        }

        public void RemoveAllPermissions()
        {
            var json = JObject.Parse(Expression);
            if (json["permissions"] == null)
            {
                return;
            }

            json.Remove("permissions");
            Expression = json.ToString(Formatting.None);
        }

        public List<AlertPermission> GetPermissions()
        {
            var json = JObject.Parse(Expression);
            if (json["permissions"] == null)
            {
                return new List<AlertPermission>();
            }

            return ParsePermissions(json["permissions"]).ToList();
        }

        private static IEnumerable<AlertPermission> ParsePermissions(JToken token)
        {
            foreach (var child in token.Children())
            {
                yield return new AlertPermission()
                {
                    Name = child.Value<string>("name"),
                    Type = (AlertPermissionType)Enum.Parse(typeof(AlertPermissionType), child.Value<string>("type"))
                };
            }
        }

        public virtual VehicleGroup VehicleGroup { get; set; }
        public virtual TrackedItemGroup TrackedItemGroup { get; set; }
        public virtual EscalationChain EscalationChain { get; set; }
        public virtual SlaAlertRule SlaAlertRule { get; set; }
        public virtual AlertWorkflow AlertWorkflow { get; set; }
        public virtual ICollection<AlertRuleNotificationRule> AlertRuleNotificationRules { get; set; }
        public virtual ICollection<AlertRuleAction> AlertRuleActions { get; set; }
        public virtual ICollection<AlertRulePeriod> AlertRulePeriods { get; set; }
        public virtual ICollection<AlertRuleTag> AlertRuleTags { get; set; }
    }
}