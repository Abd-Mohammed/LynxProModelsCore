using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class VehicleInspectionCategory
    {
        public VehicleInspectionCategory()
        {
            VehicleInspectionDefects = new HashSet<VehicleInspectionDefect>();
        }

        public int VehicleInspectionCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Description", Description = "Vehicle Inspection Category Description")]
        public string Description { get; set; }

        public virtual ICollection<VehicleInspectionDefect> VehicleInspectionDefects { get; set; }
    }
}