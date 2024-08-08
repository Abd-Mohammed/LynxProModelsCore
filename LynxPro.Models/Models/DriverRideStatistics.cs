using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DriverRideStatistics
    {
        public int DriverId { get; set; }

        [Range(1, 5)]
        [Display(Name = "Rating", Description = "Driver Rating")]
        public double Rating { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Last Updated Time", Description = "Driver Last Rating Updated Time")]
        public DateTime LastRatingUpdatedTime { get; set; }

        [Range(1, 5)]
        [Display(Name = "Highest Rating", Description = "Driver Highest Rating")]
        public double HighestRating { get; set; }

        [Range(1, 5)]
        [Display(Name = "Lowest Rating", Description = "Driver Lowest Rating")]
        public double LowestRating { get; set; }

        [Display(Name = "Number Of Ratings", Description = "Driver Number Of Ratings")]
        public int NumberOfRatings { get; set; }

        public virtual Driver Driver { get; set; }
    }
}