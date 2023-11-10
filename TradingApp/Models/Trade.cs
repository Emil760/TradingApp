namespace TradingApp.Models
{
    public abstract class Trade
    {
        public long TradeId { get; set; }
        public string Counterparty { get; set; }
        public float Quantity { get; set; }
        public long CalcEstimate { get; set; }
        public abstract double CalculatePV(float price);
        public abstract string GetKetForMarketData();
    }
}
