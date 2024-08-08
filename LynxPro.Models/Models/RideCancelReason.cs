
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class RideCancelReason : TenantAware, ITenantAware
    {
        public int RideCancelReasonId { get; set; }

        [Required]
        [MaxLength(15)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Code", Description = "Ride Cancel Reason Code")]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Ride Cancel Reason Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Ride Cancel Reason Description")]
        public string Description { get; set; }
    }
}
