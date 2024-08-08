using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverTransactionConfiguration : IEntityTypeConfiguration<DriverTransaction>
    {
        public void Configure(EntityTypeBuilder<DriverTransaction> builder)
        {
            builder.HasIndex(dt => dt.PaymentMethod);
            builder.HasIndex(dt => dt.Type);
            builder.HasIndex(dt => dt.Date);
            builder.HasIndex(dt => dt.Status);
            builder.HasIndex(dt => dt.SettledDate);

            builder.Property(dt => dt.Amount)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(dt => dt.RowVersion)
                   .IsRowVersion();

            builder.HasOne(dt => dt.ReferenceTransaction)
                   .WithMany()
                   .HasForeignKey(dt => dt.ReferenceTransactionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
