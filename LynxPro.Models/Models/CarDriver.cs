using Newtonsoft.Json;

namespace LynxPro.Models
{
    public class CarDriver
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("staffId")]
        public string StaffId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shiftNo")]
        public string ShiftNo { get; set; }

        [JsonProperty("shiftTime")]
        public DateTime ShiftTime { get; set; }

        [JsonProperty("tripCount")]
        public int TripCount { get; set; }

        [JsonProperty("income")]
        public double Income { get; set; }
    }
}
