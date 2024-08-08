
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class ApiService : TenantAware, ITenantAware
    {
        public int ApiServiceId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Service Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "API Name", Description = "Service API Name")]
        public string ApiName { get; set; }

        [Display(Name = "Created Date", Description = "Service Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "API Manager", Description = "API Manager Id")]
        public int ApiManagerId { get; set; }

        public virtual ApiManager ApiManager { get; set; }
    }
}