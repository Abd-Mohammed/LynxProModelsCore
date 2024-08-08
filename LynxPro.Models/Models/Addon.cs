using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum AddonType
    {
        [Display(Name = "Feature")]
        Feature = 1,

        [Display(Name = "Plugin")]
        Plugin = 2,
    }

    public class Addon
    {
        [Key]
        public int AddonId { get; set; }

        [Required]
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public AddonType Type { get; set; }

        public string Json { get; set; }

        [NotMapped]
        public AddonJson? AddonJson
        {
            get
            {
                return !string.IsNullOrEmpty(Json)
                    ? JsonConvert.DeserializeObject<AddonJson>(Json)
                    : new AddonJson();
            }
        }
    }

    public class AddonJson
    {
        [JsonProperty("scopes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Scopes { get; set; }

        [JsonProperty("configuration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public JToken Configuration { get; set; }
    }
}