using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();
            builder.HasIndex(c => c.Code).IsUnique();
            builder.HasIndex(c => c.Symbol).IsUnique();
        }
    }
}
