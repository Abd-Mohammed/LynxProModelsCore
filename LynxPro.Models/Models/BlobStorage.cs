
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class BlobStorage : TenantAware, ITenantAware
    {
        public int BlobStorageId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name", Description = "Blob Storage Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Connection String", Description = "Blob Storage Connection String")]
        public string ConnectionString { get; set; }

        [Display(Name = "Redundant Storage Connection String", Description = "Blob Storage Redundant Storage Connection String")]
        public string RedundantStorageConnectionString { get; set; }

        [Display(Name = "Is Active", Description = "Is Blob Storage Active")]
        public bool IsActive { get; set; }
    }
}