
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum PromoCodeUsageStatus
    {
        [Display(Name = "Pending")]
        Pending = 1,
        [Display(Name = "Claimed")]
        Claimed = 2,
        [Display(Name = "Consumed")]
        Consumed = 3
    }

    public class PromoCodeUsage : TenantAware, ITenantAware
    {
        public int PromoCodeUsageId { get; set; }

        [Display(Name = "Status", Description = "Promo Code Usage Status")]
        public PromoCodeUsageStatus Status { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Claimed Date", Description = "Promo Code Usage Claimed Date")]
        public DateTime? ClaimedDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Consumed Date", Description = "Promo Code Usage Consumed Date")]
        public DateTime? ConsumedDate { get; set; }

        [Display(Name = "Customer", Description = "Customer Id")]
        public int CustomerId { get; set; }

        [Display(Name = "Promo Code", Description = "Promo Code Id")]
        public int PromoCodeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PromoCode PromoCode { get; set; }
    }
}