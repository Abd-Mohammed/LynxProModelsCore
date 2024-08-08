using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class VehicleAccident : TenantAware, ITenantAware
    {
        public int VehicleAccidentId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Date", Description = "Accident Date")]
        public DateTime Date { set; get; }

        [Range(1, 100)]
        [Display(Name = "No Of Vehicles", Description = "Vehicle Accident No. Of Vehicles")]
        public int NoOfVehicles { get; set; }

        [Range(0, 100)]
        [Display(Name = "No Of Injuries", Description = "Vehicle Accident No. Of Injuries")]
        public int NoOfInjuries { get; set; }

        [Range(0, 100)]
        [Display(Name = "No Of Fatalities", Description = "Vehicle Accident No. Of Fatalities")]
        public int NoOfFatalities { get; set; }

        [MaxLength(250)]
        [Display(Name = "Weather/Road Conditions", Description = "Vehicle Accident Weather/Road Conditions")]
        public string WeatherRoadConditions { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Location", Description = "Vehicle Accident Location")]
        public string Location { get; set; }

        [MaxLength(250)]
        [Display(Name = "Damaged Parts", Description = "Vehicle Accident Damaged Parts")]
        public string DamagedParts { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Other Vehicle Details", Description = "Vehicle Accident Other Vehicle Details")]
        public string OtherVehicleDetails { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Other Person/Company", Description = "Vehicle Accident Other Person/Company")]
        public string OtherPersonCompany { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Other Insurance Company", Description = "Vehicle Accident Insurance Company")]
        public string OtherInsuranceCompany { get; set; }

        [MaxLength(250)]
        [Display(Name = "Notes", Description = "Vehicle Accident Notes")]
        public string Notes { get; set; }

        [MaxLength(250)]
        [Display(Name = "Party At Fault", Description = "Vehicle Accident Party At Fault")]
        public string PartyAtFault { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Decision Date", Description = "Accident Decision Date")]
        public DateTime? DecisionDate { set; get; }

        [Range(1, 10000)]
        [Display(Name = "Cost", Description = "Vehicle Accident Cost")]
        public double Cost { set; get; }

        [Range(1, 10000)]
        [Display(Name = "Deductible Amount", Description = "Vehicle Accident Deductible Amount")]
        public double DeductibleAmount { set; get; }

        [Range(1, 10000)]
        [Display(Name = "Total Expenses", Description = "Vehicle Accident Total Expenses")]
        public double TotalExpenses { set; get; }

        [Range(1, 10000)]
        [Display(Name = "Other Expenses", Description = "Vehicle Accident Other Expenses")]
        public double OtherExpenses { set; get; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Reported By", Description = "Vehicle Accident Reported By")]
        public string ReportedBy { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Vehicle Accident Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Vehicle Accident Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Vehicle Accident Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Vehicle Accident Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int? DriverId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Driver Driver { get; set; }
    }
}