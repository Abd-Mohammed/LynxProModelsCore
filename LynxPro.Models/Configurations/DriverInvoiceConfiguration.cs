using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverInvoiceConfiguration : IEntityTypeConfiguration<DriverInvoice>
    {
        public void Configure(EntityTypeBuilder<DriverInvoice> builder)
        {
            // Indexes
            builder.HasIndex(di => di.Number);
            builder.HasIndex(di => di.Status);
            builder.HasIndex(di => di.Date);
            builder.HasIndex(di => di.DueDate);
            builder.HasIndex(di => di.PaidDate);
            builder.HasIndex(di => di.ExpectedPaymentDate);

            // Properties with precision
            builder.Property(di => di.Subtotal)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(di => di.Total)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(di => di.AmountToCollect)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(di => di.AmountPaid)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(di => di.AmountAdjusted)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(di => di.Tax)
                   .HasColumnType("decimal(19, 4)");

            // RowVersion for concurrency
            builder.Property(di => di.RowVersion)
                   .IsRowVersion();
        }
    }
}
