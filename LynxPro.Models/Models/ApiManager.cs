
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum ApiStatus
    {
        Activated = 1,
        Deactivated = 2
    }

    public class ApiManager : TenantAware, ITenantAware
    {
        public ApiManager()
        {
            ApiServices = new HashSet<ApiService>();
        }

        public int ApiManagerId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "API Key", Description = "API Manager API Key")]
        public string ApiKey { get; set; }

        [Range(1, 2)]
        [Display(Name = "Status", Description = "API Manager Status")]
        public ApiStatus Status { get; set; }

        [Display(Name = "Created Date", Description = "Service Created Date")]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ApiService> ApiServices { get; set; }
    }
}