
using LynxPro.Models.Json;
using LynxPro.Models.Utils;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum InvoiceStatus
    {
        // Indicates a paid invoice.
        [Display(Name = "Paid")]
        Paid = 1,
        // Indicates the payment is not yet collected and will be in this state till the due date to indicate the due period.
        [Display(Name = "Posted")]
        Posted = 2,
        // Indicates the payment is not yet collected and is being retried as per retry settings.
        [Display(Name = "Payment Due")]
        PaymentDue = 3,
        // Indicates the payment is not made and all attempts to collect is failed.
        [Display(Name = "Not Paid")]
        NotPaid = 4,
        // Indicates a voided invoice.
        [Display(Name = "Voided")]
        Voided = 5
    }

    public enum PriceType
    {
        // All amounts in the document are exclusive of tax.
        [Display(Name = "Tax Exclusive")]
        TaxExclusive = 1,
        // All amounts in the document are inclusive of tax.
        [Display(Name = "Tax Inclusive")]
        TaxInclusive = 2
    }

    public class DriverInvoice : TenantAware, ITenantAware, IFranchiseAware, ISoftDelete, IAtomicEntity
    {
        public long DriverInvoiceId { get; set; }
        public int FranchiseId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Number", Description = "Driver Invoice Number")]
        public string Number { get; set; }

        [Range(1, 5)]
        [Display(Name = "Status", Description = "Driver Invoice Status")]
        public InvoiceStatus Status { get; set; }

        /// <summary>
        /// The price type of the invoice.
        /// </summary>
        [Range(1, 2)]
        [Display(Name = "Price Type", Description = "Driver Invoice Price Type")]
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Date indicated on the invoice. 
        /// </summary>
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Date", Description = "Driver Invoice Date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Due date of the invoice. In a business context, due date is the latest a payment can 
        /// be made on an invoice or debt before it is considered overdue.
        /// </summary>
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Due Date", Description = "Driver Invoice Due Date")]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// The invoice sub-total.
        /// </summary>
        [Range(0, 10000)]
        [Display(Name = "Subtotal", Description = "Driver Invoice Subtotal")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Invoiced amount, minimum value is zero
        /// </summary>
        [Range(0, 10000)]
        [Display(Name = "Total", Description = "Driver Invoice Total")]
        public decimal Total { get; set; }

        /// <summary>
        /// Total amount to be collected.
        /// </summary>
        [Range(0, 10000)]
        [Display(Name = "Amount To Collect", Description = "Driver Invoice Amount To Collect")]
        public decimal AmountToCollect { get; set; }

        /// <summary>
        /// Total payments received for this invoice.
        /// </summary>
        [Range(0, 100000)]
        [Display(Name = "Amount Paid", Description = "Driver Invoice Amount Paid")]
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// Total adjustments made against this invoice.
        /// </summary>
        [Range(0, 10000)]
        [Display(Name = "Amount Adjusted", Description = "Driver Invoice Amount Adjusted")]
        public decimal AmountAdjusted { get; set; }

        /// <summary>
        /// Total tax amount for this invoice.
        /// </summary>
        [Range(0, 10000)]
        [Display(Name = "Tax", Description = "Driver Invoice Tax")]
        public decimal Tax { get; set; }

        /// <summary>
        /// Expected payment date recorded for this invoice.
        /// </summary>
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Expected Payment Date", Description = "Driver Invoice Expected Payment Date")]
        public DateTime? ExpectedPaymentDate { get; set; }

        /// <summary>
        /// Timestamp indicating the date & time this invoice got paid.
        /// </summary>
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Paid Date", Description = "Driver Invoice Paid Date")]
        public DateTime? PaidDate { get; set; }

        [MaxLength(50)]
        [Display(Name = "Voided By", Description = "Driver Voided By")]
        public string VoidedBy { get; set; }

        /// <summary>
        /// Timestamp indicating the date & time this invoice got voided.
        /// </summary>
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Voided Date", Description = "Driver Invoice Voided Date")]
        public DateTime? VoidedDate { get; set; }

        /// <summary>
        /// Reason for voiding the invoice.
        /// </summary>
        [MaxLength(250)]
        [Display(Name = "Void Reason", Description = "Driver Invoice Void Reason")]
        public string VoidReason { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency Code", Description = "Driver Invoice Currency Code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// JSON document for discounts, taxes, etc..
        /// </summary>
        [Display(Name = "Document", Description = "Driver Invoice Document")]
        public string Document { get; set; }

        [NotMapped]
        public DriverInvoiceData Data { get { return JsonMapper.MapOrDefault<DriverInvoiceData>(Document); } }

        [Display(Name = "Is Deleted", Description = "Driver Invoice Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int DriverId { get; set; }

        public byte[] RowVersion { get; set; }

        public virtual Driver Driver { get; set; }

        [NotMapped]
        public decimal AmountRemaining
        {
            get
            {
                return AmountToCollect - AmountPaid;
            }
        }

        public void LinkTransaction(DriverTransaction transaction)
        {
            var data = Data ?? new DriverInvoiceData();
            var newTransactions = data.Transactions?.ToList() ?? new List<DriverInvoiceTransaction>();
            newTransactions.Add(new DriverInvoiceTransaction()
            {
                Id = transaction.DriverTransactionId,
                Amount = transaction.Amount,
                CurrencyCode = transaction.CurrencyCode,
                Date = transaction.Date,
                PaymentMethod = transaction.PaymentMethod,
                SettledBy = transaction.SettledBy,
                Type = transaction.Type
            });

            data.Transactions = newTransactions;

            Document = CustomJsonConvert.ToCamelCase(data, Formatting.None);
        }

        public void AddCreditNote(DriverInvoiceCreditNote note)
        {
            var data = Data ?? new DriverInvoiceData();
            var notes = data.CreditNotes?.ToList() ?? new List<DriverInvoiceCreditNote>();
            notes.Add(note);

            data.CreditNotes = notes;

            Document = CustomJsonConvert.ToCamelCase(data, Formatting.None);
        }

        public int ShiftId()
        {
            return Data.LinkedShifts?.First().ShiftId ?? 0;
        }
    }
}
