namespace TradingApp.Models
{
    public class Stock : Trade
    {
        public string Ticker { get; set; }

        public override decimal CalculatePV(float price)
        {
            return (decimal)Quantity * (decimal)price;
        }

        public override string GetKetForMarketData()
        {
            return Ticker;
        }
    }
}
