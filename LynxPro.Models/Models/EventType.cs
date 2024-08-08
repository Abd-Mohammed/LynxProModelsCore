using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Event Type Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Code", Description = "Event Type Code")]
        public string Code { get; set; }

        [MaxLength(7)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Color", Description = "Event Type Color")]
        public string Color { get; set; }
    }
}