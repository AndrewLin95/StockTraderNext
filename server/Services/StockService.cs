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

  public async Task<Stocks> GetStockAsync()
  {

    var request = new RestRequest("query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=QIBYL49PJ38VSZ0B");

    var response = await _client.ExecuteGetAsync(request);

    // Console.WriteLine(response.Content);
    // Console.Read();

    var stockData = JsonSerializer.Deserialize<Stocks>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    return stockData;
  }
}