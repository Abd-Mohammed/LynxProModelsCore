using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TrailerInspectionDefect
    {
        public int TrailerInspectionDefectId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Description", Description = "Trailer Inspection Defect Description")]
        public string Description { get; set; }

        [Display(Name = "Category", Description = "Trailer Inspection Category Id")]
        public int TrailerInspectionCategoryId { get; set; }

        public virtual TrailerInspectionCategory TrailerInspectionCategory { get; set; }
    }
}
