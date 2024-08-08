using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class FareMeterCommandConfiguration : IEntityTypeConfiguration<FareMeterCommand>
    {
        public void Configure(EntityTypeBuilder<FareMeterCommand> builder)
        {
            builder.HasIndex(fmc => fmc.ReferenceId);
            builder.HasIndex(fmc => fmc.SentDate);
            builder.HasIndex(fmc => fmc.RecievedDate);
        }
    }
}
