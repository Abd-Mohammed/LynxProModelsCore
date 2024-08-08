using LynxPro.Models;
using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum OrderStatus
    {
        /// <summary>
        /// Customer started the checkout process but did not complete it.
        /// </summary>
        [Display(Name = "Placed")]
        Placed = 1,
        /// <summary>
        /// Customer has completed the checkout process, but payment has yet to be confirmed.
        /// </summary>
        [Display(Name = "Awaiting Payment")]
        AwaitingPayment = 2,
        /// <summary>
        /// Order is being processed, related shipments are being scheduled.
        /// </summary>
        [Display(Name = "Processing")]
        Processing = 3,
        /// <summary>
        /// Order processing is failed.
        /// </summary>
        [Display(Name = "Processing Attempted")]
        ProcessingAttempted = 4,
        /// <summary>
        /// The order has been packed and dispatched to the carrier.
        /// </summary>
        [Display(Name = "Fulfilled")]
        Fulfilled = 5,
        /// <summary>
        /// Order has been pulled and packaged and is awaiting collection from a shipping provider.
        /// </summary>
        [Display(Name = "Shipment Confirmed")]
        ShipmentConfirmed = 6,
        /// <summary>
        /// Order has been packaged and is awaiting customer pickup from a seller-specified location.
        /// </summary>
        [Display(Name = "Awaiting Pickup")]
        AwaitingPickup = 7,
        /// <summary>
        /// Failed to pickup the order.
        /// </summary>
        [Display(Name = "Attempted Pickup")]
        AttemptedPickup = 8,
        /// <summary>
        /// Shipment has been picked-up and order will be delivered soon
        /// </summary>
        [Display(Name = "Out For Delivery")]
        OutForDelivery = 9,
        /// <summary>
        /// Failed to deliver the order. 
        /// </summary>
        [Display(Name = "Attempted Delivery")]
        AttemptedDelivery = 10,
        /// <summary>
        /// Order has been delivered.
        /// </summary>
        [Display(Name = "Delivered")]
        Delivered = 11,
        /// <summary>
        /// Order has been cancelled.
        /// </summary>
        [Display(Name = "Cancelled")]
        Cancelled = 12,
        /// <summary>
        /// Only some items in the order have been delivered.
        /// </summary>
        [Display(Name = "Partially Delivered")]
        PartiallyDelivered = 13
    }

    public class Order : TenantAware, ITenantAware
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public long OrderId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Number", Description = "Order Number")]
        public string Number { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Date", Description = "Order Date")]
        public DateTime Date { get; set; }

        [Range(1, 13)]
        [Display(Name = "Status", Description = "Order Status")]
        public OrderStatus Status { get; set; }

        [Range(0, 10000)]
        [Display(Name = "Subtotal", Description = "Order Subtotal")]
        public decimal Subtotal { get; set; }

        [Range(0, 10000)]
        [Display(Name = "Price Amount", Description = "Order Price Amount")]
        public decimal PriceAmount { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency Code", Description = "Order Price Currency Code")]
        public string PriceCurrencyCode { get; set; }

        [Display(Name = "Shipping Latitude", Description = "Order Shipping Latitude")]
        public double ShippingLatitude { get; set; }

        [Display(Name = "Shipping Longitude", Description = "Order Shipping Longitude")]
        public double ShippingLongitude { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Address Line 01", Description = "Order Shipping Address Line 01")]
        public string ShippingAddressLine01 { get; set; }

        [MaxLength(250)]
        [Display(Name = "Address Line 02", Description = "Order Shipping Address Line 02")]
        public string ShippingAddressLine02 { get; set; }

        [MaxLength(100)]
        [Display(Name = "City", Description = "Order Shipping Address City")]
        public string ShippingCity { get; set; }

        [MaxLength(100)]
        [Display(Name = "Zip Code", Description = "Order Shipping Address Zip Code")]
        public string ShippingZipCode { get; set; }

        [MaxLength(20)]
        [Display(Name = "Phone No", Description = "Order Shipping Address Phone No")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string ShippingPhoneNo { get; set; }

        [Required]
        [Display(Name = "Shipping Option Document", Description = "Order Shipping Option Document")]
        public string ShippingOptionDocument { get; set; }

        [MaxLength(500)]
        [Display(Name = "Special Instructions", Description = "Order Shipping Special Address Instructions")]
        public string SpecialInstructions { get; set; }

        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Order Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Order Created Date")]
        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        [Display(Name = "Last Status Updated By", Description = "Order Last Status Updated By")]
        public string LastStatusUpdatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Last Status Updated Date", Description = "Order Last Status Updated Date")]
        public DateTime LastStatusUpdatedDate { get; set; }

        [Display(Name = "Processing Attempted Count", Description = "Order Processing Attempted Count")]
        public int ProcessingAttemptedCount { get; set; }

        [NotMapped]
        public ShippingOptions ShippingOptions { get { return JsonMapper.Map<ShippingOptions>(ShippingOptionDocument); } }

        [Display(Name = "Customer", Description = "Customer Id")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}