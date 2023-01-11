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

  [HttpGet]
  public async Task<StockDailyResponseData> Get()
  {
    return await _stockService.GetStockAsync();
  }
}