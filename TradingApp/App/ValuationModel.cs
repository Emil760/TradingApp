using TradingApp.Models;

namespace TradingApp.App
{
    public class ValuationModel
    {
        public HashSet<MarketData> MarketDatas { get; set; }

        public ValuationResult CalculateValuationResult(Trade trade)
        {
            var valuationResult = new ValuationResult();

            if (trade is null)
            {
                valuationResult.ErrorMessage = "TRADE IS MISSING";
                return valuationResult;
            }

            valuationResult.TradeId = trade.TradeId;
            var key = trade.GetKetForMarketData();
            var marketData = MarketDatas.Where(md => md.Key == key).SingleOrDefault();

            if (marketData is null)
            {
                valuationResult.ErrorMessage = "MARKET DATA IS MISSING";
                return valuationResult;
            }

            var pv = trade.CalculatePV(marketData.Price);
            valuationResult.PV = pv;

            return valuationResult;
        }

        public IEnumerable<ValuationResult> CalculateValuationResults(IEnumerable<Trade> trades)
        {
            return trades.Select(CalculateValuationResult);
        }
    }
}
