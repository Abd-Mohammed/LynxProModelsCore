using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models.Json
{
    public class MobileDevice
    {
        [JsonProperty("name", Required = Required.Always)]
        [MaxLength(50)]
        public string Name { get; set; }

        [JsonProperty("udid", Required = Required.Always)]
        [MaxLength(100)]
        public string Udid { get; set; }

        [JsonProperty("registrationToken", Required = Required.Always)]
        [MaxLength(250)]
        public string RegistrationToken { get; set; }
    }
}
