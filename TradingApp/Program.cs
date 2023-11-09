// See https://aka.ms/new-console-template for more information
using TradingApp.App;
using TradingApp.OutputWorkers;
using TradingApp.Models;

var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

OutputWorker<MarketData> fileWorker1 = new CSVFileWorker<MarketData>();
var marketDatas = fileWorker1.Reader(baseDirectory + "Resourses\\MarketData.csv");

OutputWorker<FXOption> fileWorker2 = new CSVFileWorker<FXOption>();
var fxOptions = fileWorker2.Reader(baseDirectory + "Resourses\\FXOption.csv");

OutputWorker<Stock> fileWorker3 = new CSVFileWorker<Stock>();
var stocks = fileWorker3.Reader(baseDirectory + "Resourses\\Stock.csv");

var valutationModel = new ValuationModel();
valutationModel.MarketDatas = marketDatas.ToHashSet();

var dataSet1 = valutationModel.CalculateValuationResults(fxOptions);
var dataSet2 = valutationModel.CalculateValuationResults(stocks);

OutputWorker<ValuationResult> fileWorker4 = new CSVFileWorker<ValuationResult>();
fileWorker4.Append(dataSet1, baseDirectory + "Resourses\\Results.csv");
fileWorker4.Append(dataSet2, baseDirectory + "Resourses\\Results.csv");
