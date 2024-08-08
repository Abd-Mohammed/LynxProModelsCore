

namespace LynxPro.Models
{
    public abstract class FranchiseAware : TenantAware, ITenantAware, IFranchiseAware
    {
        public int FranchiseId { get; set; }
    }
}
