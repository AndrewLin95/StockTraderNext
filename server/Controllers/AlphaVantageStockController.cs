using Microsoft.AspNetCore.Mvc;
using StockTraderNext.Models;
using StockTraderNext.Services;

namespace StockTraderNext.Controller;

[Controller]
[Route("api/[controller]")]
public class alphaVantageController : ControllerBase
{
  private readonly AlphaVantageStockService _alphaVantageStockService;

  public alphaVantageController(AlphaVantageStockService alphaVantageStockService)
  {
    _alphaVantageStockService = alphaVantageStockService;
  }

  [HttpGet("{stockSymbol}")]
  public async Task<StockDailyResponseData> Get(string stockSymbol)
  {
    return await _alphaVantageStockService.GetStockAsync(stockSymbol);
  }
}