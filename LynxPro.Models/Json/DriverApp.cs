using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models.Json
{
    public class DriverApp
    {
        [MaxLength(100)]
        [JsonProperty("udid", Required = Required.Always)]
        public string Udid { get; set; }

        [MaxLength(250)]
        [JsonProperty("registrationToken", Required = Required.Always)]
        public string RegistrationToken { get; set; }
    }
}