namespace StockTraderNext.Models;

public class StockDailyResponseData
{
  public string label { get; set; } = null!;
  public string title { get; set; } = null!;
  public string datasetIdKey { get; set; } = null!;
  public Dictionary<string, string> stockData { get; set; } = null!;
}
