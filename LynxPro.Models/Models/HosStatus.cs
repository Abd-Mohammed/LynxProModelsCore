using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class HosStatus
    {
        public int HosStatusId { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name = "Acronym", Description = "Hos Status Acronym")]
        public string Acronym { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Description", Description = "Hos Status Description")]
        public string Description { get; set; }
    }
}