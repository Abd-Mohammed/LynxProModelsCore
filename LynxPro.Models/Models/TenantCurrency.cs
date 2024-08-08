namespace LynxPro.Models
{
    public class TenantCurrency : TenantAware, ITenantAware
    {
        public int TenantCurrencyId { get; set; }

        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
