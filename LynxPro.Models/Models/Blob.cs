
using System;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum BlobDataType
    {
        [Display(Name = "Image")]
        Image = 1,
        [Display(Name = "Video")]
        Video = 2
    }

    public class Blob : TenantAware, ITenantAware
    {
        public long BlobId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name", Description = "Blob Name")]
        public string Name { get; set; }

        [Range(1, 3)]
        [Display(Name = "Data Type", Description = "Blob Data Type")]
        public BlobDataType DataType { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Container Name", Description = "Blob Container Name")]
        public string ContainerName { get; set; }

        [Display(Name = "Details", Description = "Blob Details")]
        public string Details { get; set; }

        [Display(Name = "Is Linked", Description = "Is Blob Linked")]
        public bool IsLinked { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Area Created Date")]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Area Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Blob Storage", Description = "Blob Storage Id")]
        public int BlobStorageId { get; set; }

        public virtual BlobStorage BlobStorage { get; set; }
    }
}