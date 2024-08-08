using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class VehicleType : TenantAware, ITenantAware
    {
        public VehicleType()
        {
            RestrictedPudoLocations = new HashSet<RestrictedPudoLocation>();
        }

        public int VehicleTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Vehicle Type Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Vehicle Type Description")]
        public string Description { get; set; }

        [Range(0, 9)]
        [Display(Name = "Max Crew No", Description = "Vehicle Type Max Crew No")]
        public int MaxCrewNo { get; set; }

        [MaxLength(500)]
        [Display(Name = "Labels", Description = "Vehicle Type Labels")]
        public string Labels { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Icon Name", Description = "Vehicle Type Icon Name")]
        public string IconName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Vehicle Type Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Vehicle Type Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Vehicle Type Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Vehicle Type Modified Date")]
        public DateTime ModifiedDate { get; set; }

        // TODO: Remove data
        [NotMapped]
        [Range(1, 100000)]
        [Display(Name = "Weight Capacity", Description = "Vehicle Type Weight Capacity")]
        public int WeightCapacity { get; set; } = 1000;
        [NotMapped]
        [Range(1, 100000)]
        [Display(Name = "Volume Capacity", Description = "Vehicle Type Volume Capacity")]
        public int VolumeCapacity { get; set; } = 1000;
        [NotMapped]
        [Range(0.1d, 1000d)]
        [Display(Name = "Fuel Cost", Description = "Vehicle Type Fuel Cost")]
        public double? FuelCost { get; set; } = 0.15; // Default value that is used in fule surcharge calculations

        public virtual VehicleTypeLoad Load { get; set; }
        public virtual ICollection<RestrictedPudoLocation> RestrictedPudoLocations { get; set; }
    }
}