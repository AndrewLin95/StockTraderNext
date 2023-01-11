namespace StockTraderNext.Models;

public class StockDailyResponseData
{
  public string label { get; set; } = null!;
  public string title { get; set; } = null!;
  public string datasetIdKey { get; set; } = null!;
  public List<StockData> stockData { get; set; } = null!;
}

public class StockData
{
  public string stockPrice { get; set; } = null!;
  public string time { get; set; } = null!;
}