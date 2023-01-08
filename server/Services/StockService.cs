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

  public async Task<String> GetStockAsync()
  {

    var request = new RestRequest("query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=QIBYL49PJ38VSZ0B");

    var response = await _client.ExecuteGetAsync(request);

    Console.WriteLine(response.Content);
    Console.Read();

    return "test";
  }







  // private readonly HttpClient _httpClient;

  // public StockService(HttpClient httpClient)
  // {
  //   _httpClient = httpClient;
  //   _httpClient.BaseAddress = new Uri("https://www.alphavantage.co/");
  // }

  // public async Task<String> GetStockAsync()
  // {
  //   var response = await _httpClient.GetAsync("query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=QIBYL49PJ38VSZ0B");

  //   response.EnsureSuccessStatusCode();

  //   using var responseStream = await response.Content.ReadAsStreamAsync();
  //   var responseObject = await JsonSerializer.DeserializeAsync<Stocks>(responseStream);

  //   Console.WriteLine(responseObject);
  //   return "test";
  // }
}