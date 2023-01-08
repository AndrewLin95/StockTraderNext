using System.Text.Json.Serialization;
namespace StockTraderNext.Models;

public class Stocks
{
  [JsonPropertyName("Meta Data")]
  public MetaData metaData { get; set; } = null!;
  [JsonPropertyName("Time Series (5min)")]
  public Dictionary<string, Time> timeSeries { get; set; } = null!;
}

public class MetaData
{
  [JsonPropertyName("1. Information")]
  public string information { get; set; } = null!;
  [JsonPropertyName("2. Symbol")]
  public string symbol { get; set; } = null!;
  [JsonPropertyName("3. Last Refreshed")]
  public string lastRefresh { get; set; } = null!;
  [JsonPropertyName("4. Interval")]
  public string interval { get; set; } = null!;
  [JsonPropertyName("5. Output Size")]
  public string outputSize { get; set; } = null!;
  [JsonPropertyName("6. Time Zone")]
  public string timeZone { get; set; } = null!;
}

public class Time
{
  [JsonPropertyName("1. open")]
  public string _1Open { get; set; } = null!;
  [JsonPropertyName("2. high")]
  public string _2High { get; set; } = null!;
  [JsonPropertyName("3. low")]
  public string _3Low { get; set; } = null!;
  [JsonPropertyName("4. close")]
  public string _4Close { get; set; } = null!;
  [JsonPropertyName("5. volume")]
  public string _5Volume { get; set; } = null!;
}
