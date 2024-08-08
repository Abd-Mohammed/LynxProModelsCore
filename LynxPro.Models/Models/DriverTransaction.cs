
using LynxPro.Models.Json;
using LynxPro.Models.Utils;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum PaymentMethod
    {
        [Display(Name = "Card")]
        Card = 1,
        [Display(Name = "Cash")]
        Cash = 2,
        [Display(Name = "Check")]
        Check = 3,
        // Chargeback is only application when type is Refund.
        [Display(Name = "Chargeback")]
        Chargeback = 4,
        [Display(Name = "Bank Transfer")]
        BankTransfer = 5,
        [Display(Name = "Direct Debit")]
        DirectDebit = 6
    }

    public enum TransactionType
    {
        // The transaction represents an authorization for capturing the amount from the customer's payment source
        [Display(Name = "Authorization")]
        Authorization = 1,
        // The transaction represents capture of amount from the customer's payment source.
        [Display(Name = "Payment")]
        Payment = 2,
        // The transaction represents a refund of amount to the customer's payment source.
        [Display(Name = "Refund")]
        Refund = 3,
        // Indicates a reversal transaction.
        [Display(Name = "Payment Reversal")]
        PaymentReversal = 4
    }

    public enum TransactionStatus
    {
        // Transaction is being processed by the gateway.
        // This typically happens for direct debit transactions or, in case of cards, refund transactions.
        // Such transactions can take 2-7 days to complete, depending on the gateway and payment method.
        [Display(Name = "In Progress")]
        InProgress = 1,
        // The transaction is successful.
        [Display(Name = "Success")]
        Success = 2,
        // The transaction got voided or authorization expired at gateway.
        [Display(Name = "Voided")]
        Voided = 3,
        // Transaction failed.
        [Display(Name = "Failure")]
        Failure = 4,
        // Transaction failed because of Gateway not accepting the connection.
        [Display(Name = "Timeout")]
        Timeout = 5,
        // Connection with Gateway got terminated abruptly. So, status of this transaction needs to be resolved manually.
        [Display(Name = "Needs Attention")]
        NeedsAttention = 6
    }

    public enum FraudFlag
    {
        // The transaction has been marked as safe.
        [Display(Name = "Safe")]
        Safe = 1,
        // The transaction has been identified as potentially fraudulent by the gateway.
        [Display(Name = "Suspicious")]
        Suspicious = 2,
        // The transaction has been marked as fraudulent.
        [Display(Name = "Fraudulent")]
        Fraudulent = 3
    }

    public enum AuthorizationReason
    {
        // The transaction has been created to block the funds from payment method.
        [Display(Name = "Blocking Funds")]
        BlockingFunds = 1,
        // The transaction has been created for payment method verification.
        [Display(Name = "Verification")]
        Verification = 2
    }

    public class DriverTransaction : TenantAware, ITenantAware, ISoftDelete, IAtomicEntity
    {
        public long DriverTransactionId { get; set; }

        [Range(1, 6)]
        [Display(Name = "Payment Method", Description = "Driver Transaction Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Range(1, 4)]
        [Display(Name = "Type", Description = "Driver Transaction Type")]
        public TransactionType Type { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Date", Description = "Driver Transaction Date")]
        public DateTime Date { get; set; }

        [Range(1, 10000)]
        [Display(Name = "Amount", Description = "Driver Transaction Amount")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency Code", Description = "Driver Transaction Currency Code")]
        public string CurrencyCode { get; set; }

        [Range(1, 6)]
        [Display(Name = "Status", Description = "Driver Transaction Status")]
        public TransactionStatus? Status { get; set; }

        /// <summary>
        /// Type of authorization transaction.
        /// </summary>
        [Range(1, 2)]
        [Display(Name = "Authorization Reason", Description = "Driver Transaction Authorization Reason")]
        public AuthorizationReason? AuthorizationReason { get; set; }

        /// <summary>
        /// Timestamp indicating when the payment was voided or authorization expired at gateway.
        /// </summary>
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Voided Date", Description = "Driver Transaction Voided Date")]
        public DateTime? VoidedDate { get; set; }

        /// <summary>
        /// Indicates whether or not the transaction has been identified as fraudulent.
        /// </summary>
        [Range(1, 3)]
        [Display(Name = "Fraud Flag", Description = "Driver Transaction Fraud Flag")]
        public FraudFlag? FraudFlag { get; set; }

        /// <summary>
        /// Short description why the transaction was marked as fraud/suspicious.
        /// </summary>
        [MaxLength(250)]
        [Display(Name = "Fraud Reason", Description = "Driver Transaction Fraud Reason")]
        public string FraudReason { get; set; }

        /// <summary>
        /// Indicates the user at which the final status of the transaction has been marked.
        /// </summary>
        [Display(Name = "Settled By", Description = "Driver Transaction Settled By")]
        public string SettledBy { get; set; }

        /// <summary>
        /// Indicates the time at which the final status of the transaction has been marked.
        /// </summary>
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Settled Date", Description = "Driver Transaction Settled Date")]
        public DateTime? SettledDate { get; set; }

        /// <summary>
        /// JSON document for linked payments, invoices, etc..
        /// </summary>
        [Display(Name = "Document", Description = "Driver Transaction Document")]
        public string Document { get; set; }

        [NotMapped]
        public DriverTransactionData Data { get { return JsonMapper.MapOrDefault<DriverTransactionData>(Document); } }

        [Display(Name = "Is Deleted", Description = "Is Driver Transaction Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int DriverId { get; set; }

        [Display(Name = "Reference Transaction", Description = "Reference Transaction Id")]
        public long? ReferenceTransactionId { get; set; }

        public byte[] RowVersion { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual DriverTransaction ReferenceTransaction { get; set; }

        [NotMapped]
        public string AmountDisplay
        {
            get
            {
                return Amount.ToMoney(CurrencyCode).Text;
            }
        }

        public void LinkInvoice(DriverInvoice invoice)
        {
            var data = Data ?? new DriverTransactionData();
            var newInvoices = data.LinkedInvoices?.ToList() ?? new List<DriverTransactionInvoice>();
            newInvoices.Add(new DriverTransactionInvoice()
            {
                Id = invoice.DriverInvoiceId,
                Date = invoice.Date,
                Number = invoice.Number,
            });

            var newData = data;
            newData.LinkedInvoices = newInvoices;

            Document = CustomJsonConvert.ToCamelCase(newData, Formatting.None);
        }

        public void SetRemarks(string remarks)
        {
            var newData = Data ?? new DriverTransactionData();
            newData.Remarks = remarks;

            Document = CustomJsonConvert.ToCamelCase(newData, Formatting.None);
        }
    }
}