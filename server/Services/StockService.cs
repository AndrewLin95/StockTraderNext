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

  // returns the intraday stock data
  public async Task<StockDailyResponseData> GetStockAsync()
  {
    // GET request to alpha vantage
    var request = new RestRequest("query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=QIBYL49PJ38VSZ0B");
    var response = await _client.ExecuteGetAsync(request);
    // Deserializes the data to align with the Stocks model
    var responseData = JsonSerializer.Deserialize<Stocks>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    // Only collects the stock prices if they are within trading hours (every 5 minutes)
    var stockValues = new List<StockData>();

    foreach (var item in responseData.timeSeries)
    {
      // NOTE: alpha vantage's intra date values are -1 day. The below "current day" takes this into account
      var currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
      var currentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
      var currentDay = Int32.Parse(DateTime.Now.ToString("dd"));
      var dateTimeLow = new DateTime(currentYear, currentMonth, currentDay - 1, 08, 30, 00);
      var dateTimeHigh = new DateTime(currentYear, currentMonth, currentDay - 1, 16, 05, 00);

      var parseTime = DateTime.Parse(item.Key);

      var compareLowResults = DateTime.Compare(parseTime, dateTimeLow);
      var compareHighResults = DateTime.Compare(parseTime, dateTimeHigh);

      // result > 0 = after, result < 0 = before
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