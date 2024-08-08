using LynxPro.Models.Json;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class Toll : TenantAware, ITenantAware, IIntegrationAware
    {
        public int TollId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Toll Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Toll Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Overlay", Description = "Toll Overlay")]
        public string Overlay { get; set; }

        [Required]
        [Display(Name = "Toll", Description = "Toll Location")]
        public Geometry Location { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Fee", Description = "Toll Fee")]
        public decimal Fee { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency Code", Description = "Toll Currency Code")]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(1000)]
        [Display(Name = "Options", Description = "Toll Options")]
        public string OptionDocument { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Toll Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Toll Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Toll Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Toll Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Integration Id", Description = "Toll Integration Id")]
        public int? IntegrationId { get; set; }

        [NotMapped]
        public TollOptions Options { get { return JsonMapper.Map<TollOptions>(OptionDocument); } }
    }
}