
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class MasterRoute : TenantAware, ITenantAware
    {
        public int MasterRouteId { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Unique Id", Description = "Master Route Unqiue Id")]
        public string UniqueId { get; set; }

        [Required]
        [Display(Name = "Encoded Path", Description = "Master Route Encoded Path")]
        public string EncodedPath { get; set; }

        /// <summary>
        /// Master route JSON which holds extra data
        /// </summary>
        [Required]
        [Display(Name = "Document", Description = "Route Document")]
        public string Document { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Master Route Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Master Route Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Master Route Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Master Route Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}