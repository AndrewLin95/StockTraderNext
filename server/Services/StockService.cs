using StockTraderNext.Models;
using RestSharp;
using System.Text.Json;

namespace StockTraderNext.Services;

public class StockService
{
  private readonly RestClient _client;

  public StockService()
  {
    var url = "https://www.alphavantage.co/";
    _client = new RestClient(url);
  }

  public async Task<StockDailyResponseData> GetStockAsync()
  {

    var request = new RestRequest("query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=QIBYL49PJ38VSZ0B");

    var response = await _client.ExecuteGetAsync(request);

    // Console.WriteLine(response.Content);
    // Console.Read();

    var responseData = JsonSerializer.Deserialize<Stocks>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    var stockValues = new List<StockData>();

    foreach (var item in responseData.timeSeries)
    {
      var currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
      var currentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
      var currentDay = Int32.Parse(DateTime.Now.ToString("dd"));
      var dateTimeLow = new DateTime(currentYear, currentMonth, currentDay - 1, 08, 30, 00);
      var dateTimeHigh = new DateTime(currentYear, currentMonth, currentDay - 1, 16, 05, 00);

      var parseTime = DateTime.Parse(item.Key);

      var compareLowResults = DateTime.Compare(parseTime, dateTimeLow);
      var compareHighResults = DateTime.Compare(parseTime, dateTimeHigh);

      if (compareLowResults > 0 && compareHighResults < 0)
      {
        stockValues.Add(new StockData { stockPrice = item.Value._1Open, time = item.Key });
      }
    };

    var stockData = new StockDailyResponseData
    {
      label = $"{responseData.metaData.symbol} {responseData.metaData.information}",
      title = $"{responseData.metaData.symbol}",
      datasetIdKey = $"{responseData.metaData.symbol} {responseData.metaData.lastRefresh}",
      stockData = stockValues
    };

    return stockData;
  }
}