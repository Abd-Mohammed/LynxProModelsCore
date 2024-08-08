using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum VehicleInsuranceType
    {
        [Display(Name = "Liability Coverage")]
        LiabilityCoverage = 1,
        [Display(Name = "Collision Insurance")]
        CollisionInsurance = 2,
        [Display(Name = "Comprehensive Insurance")]
        ComprehensiveInsurance = 3,
        [Display(Name = "Underinsured Motorist Insurance")]
        UnderinsuredMotoristInsurance = 4,
        [Display(Name = "Medical Payments Coverage")]
        MedicalPaymentsCoverage = 5,
        [Display(Name = "Personal Injury Protection Insurance")]
        PersonalInjuryProtectionInsurance = 6,
        [Display(Name = " Gap Insurance")]
        GapInsurance = 7,
        [Display(Name = "Towing and Labor Insurance")]
        TowingAndLaborInsurance = 8,
        [Display(Name = "Rental Reimbursement Insurance")]
        RentalReimbursementInsurance = 9,
        [Display(Name = "Classic Car Insurance")]
        ClassicCarInsurance = 10,
    }

    public enum VehicleRegistrationStatus
    {
        [Display(Name = "Valid")]
        Valid = 1,
        [Display(Name = "Suspended")]
        Suspended = 2,
        [Display(Name = "Expired")]
        Expired = 3,
    }

    public class VehicleRegistration : TenantAware, ITenantAware
    {
        public int VehicleRegistrationId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Date", Description = "Vehicle Registration Date")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Number", Description = "Vehicle Registration Number")]
        public string Number { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Owner Name", Description = "Vehicle Registration Owner Name")]
        public string OwnerName { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Owner Address", Description = "Vehicle Registration Owner Address")]
        public string OwnerAddress { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Insurance Policy Number", Description = "Vehicle Registration Insurance Policy Number")]
        public string InsurancePolicyNumber { get; set; }

        [Range(1, 10)]
        [Display(Name = "Insurance Type", Description = "Vehicle Registration Insurance Type")]
        public VehicleInsuranceType InsuranceType { set; get; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Insurance Company", Description = "Vehicle Registration Insurance Company")]
        public string InsuranceCompany { set; get; }

        [Range(1, 10000)]
        [Display(Name = "Insurance Fee", Description = "Vehicle Registration Insurance Fee")]
        public double InsuranceFee { set; get; }

        [Range(1, 3)]
        [Display(Name = "Vehicle Status", Description = "Vehicle Registration Status")]
        public VehicleRegistrationStatus Status { set; get; }

        [Range(1, 10000)]
        [Display(Name = "Fee", Description = "Vehicle Registration Fee")]
        public double Fee { set; get; }

        [MaxLength(250)]
        [Display(Name = "Notes", Description = "Vehicle Registration Notes")]
        public string Notes { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Vehicle Registration Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Vehicle Registration Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Vehicle Registration Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Vehicle Registration Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}