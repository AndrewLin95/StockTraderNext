using StockTraderNext.Models;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StockTraderNext.Services;

public class StockService
{
  private readonly RestClient _client;

  public StockService()
  {
    _client = new RestClient("https://www.alphavantage.co/");
  }


  public async Task<Stocks> GetStockAsync()
  {
    var request = new RestRequest("query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=QIBYL49PJ38VSZ0B");
    var response = await _client.ExecuteGetAsync(request);

    if (!response.IsSuccessful)
    {
      Console.WriteLine(response);
    }

    var stockData = JsonSerializer.Deserialize<Stocks>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    return stockData;
  }
}