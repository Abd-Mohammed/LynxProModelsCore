namespace LynxPro.Models.Utils
{
    public struct Money
    {
        public decimal Value { get; set; }

        public string Text { get; set; }
    }

    public static class MoneyExtensions
    {
        public static Money ToMoney(this decimal value)
        {
            var money = System.Math.Round(value, 3);
            return new Money()
            {
                Value = money,
                Text = string.Format("{0:0.000}", money)
            };
        }

        public static Money ToMoney(this decimal value, string currencyCode)
        {
            var money = System.Math.Round(value, 3);
            return new Money()
            {
                Value = money,
                Text = string.Concat(string.Format("{0:0.000}", money), " ", currencyCode)
            };
        }
    }
}
