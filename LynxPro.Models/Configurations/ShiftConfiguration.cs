using System.Data.Entity.ModelConfiguration;

namespace LynxPro.Models.Configurations
{
    public class ShiftConfiguration : EntityTypeConfiguration<Shift>
    {
        public ShiftConfiguration()
        {
            HasIndex(sh => sh.Name);
            //HasIndex(dw => new { dw.Name, dw.TenantId }).IsUnique();
        }
    }
}