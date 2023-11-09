namespace TradingApp.Models
{
    public class ValuationResult
    {
        public long TradeId { get; set; }
        public decimal PV { get; set; }
        public string ErrorMessage { get; set; }
    }
}
