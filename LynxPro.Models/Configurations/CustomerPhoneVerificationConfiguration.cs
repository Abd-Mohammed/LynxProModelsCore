using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class CustomerPhoneVerificationConfiguration : IEntityTypeConfiguration<CustomerPhoneVerification>
    {
        public void Configure(EntityTypeBuilder<CustomerPhoneVerification> builder)
        {
            // Primary key
            builder.HasKey(cpv => cpv.CustomerId);

            builder.HasOne(cpv => cpv.Customer)
                   .WithOne(c => c.PhoneVerification)
                   .HasForeignKey<CustomerPhoneVerification>(cpv => cpv.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
