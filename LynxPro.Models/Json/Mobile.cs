using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models.Json
{
    public class Mobile
    {
        [MaxLength(100)]
        [JsonProperty("udid", Required = Required.Always)]
        public string Udid { get; set; }

        [MaxLength(250)]
        [JsonProperty("registrationToken", Required = Required.Always)]
        public string RegistrationToken { get; set; }

        [JsonProperty("primary", Required = Required.Always)]
        public bool Primary { get; set; }

        [JsonProperty("reference", Required = Required.DisallowNull)]
        public Guid? Reference { get; set; }
    }
}
