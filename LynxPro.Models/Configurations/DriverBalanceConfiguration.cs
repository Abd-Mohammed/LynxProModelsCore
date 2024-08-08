using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverBalanceConfiguration : IEntityTypeConfiguration<DriverBalance>
    {
        public void Configure(EntityTypeBuilder<DriverBalance> builder)
        {
            // Primary key
            builder.HasKey(db => db.DriverId);

            // Properties
            builder.Property(db => db.Balance)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(db => db.RowVersion)
                   .IsRowVersion();

            // Relationships
            builder.HasOne(db => db.Driver)
                   .WithOne(d => d.Balance)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(db => db.LastPaymentTransaction)
                   .WithMany()
                   .HasForeignKey(db => db.LastPaymentTransactionId);

            builder.HasOne(db => db.LastInvoice)
                   .WithMany()
                   .HasForeignKey(db => db.LastInvoiceId);
        }
    }
}
