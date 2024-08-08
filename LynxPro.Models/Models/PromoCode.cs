
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LynxPro.Models
{
    public enum PromoCodeDiscountType
    {
        [Display(Name = "Flat Rate")]
        FlatRate = 1,
        [Display(Name = "Percent")]
        Percent = 2
    }

    public enum PromoCodeType
    {
        [Display(Name = "Public")]
        Public = 1, // Anyone 
        [Display(Name = "Private")]
        Private = 2, // A specific group of customers
        [Display(Name = "Restricted")]
        Restricted = 3 // Single customer 
    }

    public class PromoCode : TenantAware, ITenantAware
    {
        public PromoCode()
        {
            Usages = new HashSet<PromoCodeUsage>();
        }

        public int PromoCodeId { get; set; }

        [Range(1, 3)]
        [Display(Name = "Type", Description = "Promo Code Type")]
        public PromoCodeType Type { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Promo Code Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Number", Description = "Promo Code Number")]
        public string Number { get; set; }

        [Range(1, 2)]
        [Display(Name = "Discount Type", Description = "Promo Code Discount Type")]
        public PromoCodeDiscountType DiscountType { get; set; }

        [Range(1, 10000)]
        [Display(Name = "Discount Flat Rate", Description = "Promo Code Flat Rate")]
        public decimal? DiscountFlatRate { get; set; }

        [Range(0.01, 1)]
        [Display(Name = "Discount Percentage", Description = "Promo Code Discount Percentage")]
        public double? DiscountPercentage { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Max Promo Amount", Description = "Promo Code Max Promo Amount")]
        public decimal? MaxPromoAmount { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency Code", Description = "Promo Code Currency Code")]
        public string CurrencyCode { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Activation Date", Description = "Promo Code Activation Date")]
        public DateTime ActivationDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Expiration Date", Description = "Promo Code Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Range(1, 10)]
        [Display(Name = "Max Use Per Customer", Description = "Promo Code Max Use Per Customer")]
        public int MaxUsePerCustomer { get; set; }

        [Display(Name = "City", Description = "Promo Code City")]
        public int? CityId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Promo Code Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Promo Code Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Promo Code Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Promo Code Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Integration Id", Description = "Promo Code Integration Id")]
        public int? IntegrationId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<PromoCodeUsage> Usages { get; set; }

        /// <summary>
        /// Check if the promocode is available for usage based on the given params. IMPORTANT PromoCode City must be included.
        /// </summary>
        public PromoCodeAvailability CheckAvailability(DateTime expectedUsageDate, double latitude, double longitude, int customerCurrentUsageCount = 0)
        {
            // If customer has already reached the maximum usages.
            if (customerCurrentUsageCount >= MaxUsePerCustomer)
            {
                return PromoCodeAvailability.UsageLimitExceeded;
            }

            if (expectedUsageDate > ExpirationDate)
            {
                return PromoCodeAvailability.Expired;
            }

            if (expectedUsageDate < ActivationDate)
            {
                return PromoCodeAvailability.Invalid;
            }

            // Make sure that the code is valid in the city.
            if (CityId != null)
            {
                // City must be included.
                if (City == null)
                {
                    throw new Exception("City navigation property must be included for promo code in order to check city validity.");
                }

                // Check if the pickup location is located within the promo code city bounds.
                //var location = DbGeography.FromText(string.Format(CultureInfo.InvariantCulture, "POINT({0} {1})", longitude, latitude));

                // TODo : Uncommit the code
                //var location = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
                //if (!location.Intersects(City.Location))
                //{
                //    return PromoCodeAvailability.InvalidCity;
                //}
            }

            // Otherwise consider the promotion is available for usage.
            return PromoCodeAvailability.Available;
        }
    }

    public enum PromoCodeAvailability
    {
        Available = 1,
        Expired = 2,
        UsageLimitExceeded = 3,
        InvalidCity = 4,
        Invalid = 5,
    }
}