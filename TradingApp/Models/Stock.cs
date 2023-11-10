namespace TradingApp.Models
{
    public class Stock : Trade
    {
        public string Ticker { get; set; }

        public override double CalculatePV(float price)
        {
            return (double)Quantity * price;
        }

        public override string GetKetForMarketData()
        {
            return Ticker;
        }
    }
}