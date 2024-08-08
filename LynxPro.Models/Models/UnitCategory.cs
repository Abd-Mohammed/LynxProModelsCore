using LynxPro.Models.Json;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class UnitCategory : TenantAware, ITenantAware
    {
        public int UnitCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Unit Category Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Unit Category Description")]
        public string Description { get; set; }

        [Display(Name = "Metadata", Description = "Unit Category Metadata")]
        public string Metadata { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Unit Category Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Unit Category Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Unit Category Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Unit Category Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public List<UnitCategoryAttribute> GetAttributes()
        {
            if (Metadata == null)
            {
                return new List<UnitCategoryAttribute>();
            }

            return JsonConvert.DeserializeObject<List<UnitCategoryAttribute>>(Metadata);
        }
    }
}