
namespace StockTraderNext.Models;

public class StockService
{
  public MetaData metaData { get; set; } = null!;
  public TimeSeries timeSeries { get; set; } = null!;
}

public class MetaData
{
  public string information { get; set; } = null!;
  public string symbol { get; set; } = null!;
  public string lastRefresh { get; set; } = null!;
  public string interval { get; set; } = null!;
  public string outputSize { get; set; } = null!;
  public string timeZone { get; set; } = null!;
}

public class TimeSeries
{
  public Time time { get; set; } = null!;
}

public class Time
{
  public string _1Open { get; set; } = null!;
  public string _2High { get; set; } = null!;
  public string _3Low { get; set; } = null!;
  public string _4Close { get; set; } = null!;
  public string _5Volume { get; set; } = null!;
}