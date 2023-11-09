using TradingApp.Enums;

namespace TradingApp.Models
{
    public class FXOption : Trade
    {
        public string CurrencyPair { get; set; }
        public float Strike { get; set; }
        public DateTime ExpiryDate { get; set; }
        public FXOptionType OptionType { get; set; }

        public override decimal CalculatePV(float price)
        {
            if (OptionType == FXOptionType.Call)
                return (decimal)Quantity * (decimal)(price > Strike ? Strike : price);
            else if (OptionType == FXOptionType.Put)
                return (decimal)Quantity * (decimal)(price > Strike ? price : Strike);
            else
                return 0;
        }

        public override string GetKetForMarketData()
        {
            return CurrencyPair;
        }
    }
}
