export interface StockDailyResponseData {
  label: string;
  title: string;
  datasetIdKey: string;
  stockData: StockData[];
}

interface StockData {
  stockPrice: string;
  time: string;
}
