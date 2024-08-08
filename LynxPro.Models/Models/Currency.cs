using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class Currency
    {
        public int CurrencyId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Name", Description = "Currency Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Code", Description = "Currency Code")]
        public string Code { get; set; }

        [Required]
        [MaxLength(5)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Symbol", Description = "Currency Symbol")]
        public string Symbol { get; set; }
    }
}
