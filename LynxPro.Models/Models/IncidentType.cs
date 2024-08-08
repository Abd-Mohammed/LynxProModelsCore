
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class IncidentType : TenantAware, ITenantAware
    {
        public IncidentType()
        {
            Children = new HashSet<IncidentType>();
        }

        public int IncidentTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Incident Type Name")]
        public string Name { get; set; }

        [Display(Name = "Blob Name", Description = "Incident Type Blob Name")]
        public string BlobName { get; set; }

        [Display(Name = "Parent", Description = "Incident Type Parent")]
        public int? ParentId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Incident Type Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Incident Type Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Incident Type Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Incident Type Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual IncidentType Parent { get; set; }
        public virtual ICollection<IncidentType> Children { get; set; }
    }
}