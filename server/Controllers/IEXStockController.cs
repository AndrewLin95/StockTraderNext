using StockTraderNext.Services;
using StockTraderNext.Models;
using Microsoft.AspNetCore.Mvc;

namespace StockTraderNext.Controller;

[Controller]
[Route("api/[controller]")]
public class IEXStockController : ControllerBase
{
  private readonly IEXStockServices _IEXStockServices;

  public IEXStockController(IEXStockServices iexStockServices)
  {
    _IEXStockServices = iexStockServices;
  }

  [HttpGet]
  public async Task<int> Get()
  {
    return await _IEXStockServices.GetData();
  }
}