
using LynxPro.Models.Json;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class DriverBalance : TenantAware, ITenantAware, IAtomicEntity
    {
        public int DriverId { get; set; }

        [Display(Name = "Balance", Description = "Driver Balance")]
        public decimal Balance { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency Code", Description = "Driver Balance Currency Code")]
        public string CurrencyCode { get; set; }

        [Display(Name = "Last Payment Transaction Id", Description = "Last Payment Transaction Id")]
        public long? LastPaymentTransactionId { get; set; }

        [Display(Name = "Last Invoice Id", Description = "Last Invoice Id")]
        public long? LastInvoiceId { get; set; }

        [Display(Name = "Unbilled Amount", Description = "Driver Balance Unbilled Amount")]
        public decimal UnbilledAmount { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Unbilled Last Updated Date", Description = "Driver Balance Unbilled Last Updated Date")]
        public DateTime UnbilledLastUpdatedDate { get; set; }

        [Required]
        [Display(Name = "Document", Description = "Driver Balance Document")]
        public string Document { get; set; }

        [NotMapped]
        public IEnumerable<DriverUnbilledTripCharge> UnbilledTripCharges
        {
            get
            {
                return JsonMapper.Map<DriverBalanceDetails>(Document).UnbilledTripCharges
                    ?? Enumerable.Empty<DriverUnbilledTripCharge>();
            }
        }

        public byte[] RowVersion { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual DriverTransaction LastPaymentTransaction { get; set; }
        public virtual DriverInvoice LastInvoice { get; set; }
    }
}