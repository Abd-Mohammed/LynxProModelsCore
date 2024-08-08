using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class VehicleInspectionDefect
    {
        public int VehicleInspectionDefectId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Description", Description = "Vehicle Inspection Defect Description")]
        public string Description { get; set; }

        [Display(Name = "Category", Description = "Vehicle Inspection Category Id")]
        public int VehicleInspectionCategoryId { get; set; }

        public VehicleInspectionCategory VehicleInspectionCategory { get; set; }
    }
}
