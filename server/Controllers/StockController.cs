using Microsoft.AspNetCore.Mvc;
using StockTraderNext.Models;
using StockTraderNext.Services;

namespace StockTraderNext.Controller;

[Controller]
[Route("api/[controller]")]
public class stockController : ControllerBase
{
  private readonly StockService _stockService;

  public stockController(StockService stockService)
  {
    _stockService = stockService;
  }

  [HttpGet("{stockSymbol}")]
  public async Task<StockDailyResponseData> Get(string stockSymbol)
  {
    return await _stockService.GetStockAsync(stockSymbol);
  }
}