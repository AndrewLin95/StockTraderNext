using StockTraderNext.Models;
using RestSharp;
using System.Text.Json;

namespace StockTraderNext.Services;

public class IEXStockServices
{
  private readonly RestClient _client;

  public IEXStockServices()
  {
    var url = "https://cloud.iexapis.com/";
    _client = new RestClient(url);
  }

  public async Task<int> GetData()
  {
    var placeholderNumber = 32;
    return placeholderNumber;
  }
  // /stable/stock/aapl/quote?token=TOKEN
}