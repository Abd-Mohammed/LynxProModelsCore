using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TrailerInspectionCategory
    {
        public TrailerInspectionCategory()
        {
            TrailerInspectionDefects = new HashSet<TrailerInspectionDefect>();
        }

        public int TrailerInspectionCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Description", Description = "Trailer Inspection Category Description")]
        public string Description { get; set; }

        public virtual ICollection<TrailerInspectionDefect> TrailerInspectionDefects { get; set; }
    }
}