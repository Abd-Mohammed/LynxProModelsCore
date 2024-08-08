using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LynxPro.Models.Json
{
    public class AddonConfig
    {
        [JsonProperty("addons", Required = Required.Always)]
        public IEnumerable<Addon> Addons { get; set; }
    }

    public class Addon
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("code", Required = Required.DisallowNull)]
        public string Code { get; set; }

        [JsonProperty("name", Required = Required.DisallowNull)]
        public string Name { get; set; }

        [JsonProperty("custom", Required = Required.DisallowNull)]
        public bool? Custom { get; set; }

        [JsonProperty("source", Required = Required.DisallowNull)]
        public string Source { get; set; }

        [JsonProperty("shortcutLink", Required = Required.DisallowNull)]
        public AddonShortcutLink ShortcutLink { get; set; }

        [JsonProperty("allowedUsers", Required = Required.DisallowNull)]
        public List<string> AllowedUsers { get; set; }
    }

    public class AddonShortcutLink
    {
        [JsonProperty("enabled", Required = Required.DisallowNull)]
        public bool? Enabled { get; set; }

        [JsonProperty("grouped", Required = Required.DisallowNull)]
        public bool? Grouped { get; set; }
    }

    public static class AddonExtensions
    {
        public static bool HasVisionDetectionAddon(this IEnumerable<Addon> addons)
        {
            return addons.Any(a => a.Id.Equals("vision_detection_people_count"));
        }

        public static bool HasBehaviorAddon(this IEnumerable<Addon> addons)
        {
            return addons.Any(a => a.Id.StartsWith("vision_behaviors"));
        }

        public static bool HasBehaviorAddonPhone(this IEnumerable<Addon> addons)
        {
            return addons.Any(a => a.Id.StartsWith("vision_behaviors_phone"));
        }

        public static bool HasVisionAddon(this IEnumerable<Addon> addons)
        {
            return addons.Any(a => a.Id.StartsWith("vision"));
        }

        public static IEnumerable<Addon> VisionAddons(this IEnumerable<Addon> addons)
        {
            return addons.Where(a => a.Id.StartsWith("vision"));
        }

        public static IEnumerable<Addon> CustomAddons(this IEnumerable<Addon> addons)
        {
            return addons.Where(a => !string.IsNullOrEmpty(a.Source));
        }

        public static Addon SingleCustomOrDefault(this IEnumerable<Addon> addons, string code)
        {
            return addons.SingleOrDefault(a => !string.IsNullOrEmpty(a.Source) && a.Code == code.ToLower());
        }
    }
}