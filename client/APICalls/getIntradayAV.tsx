import { StockDailyResponseData } from '../utils/Models';

export default async function getIntradayAV(stockSymbol: string[]) {
  const arrayLength = stockSymbol.length;
  console.log(arrayLength);

  const stockData: StockDailyResponseData[] = [];

  let i = 0;
  while (i < arrayLength) {
    const url = `/api/stock/${stockSymbol[i]}`;

    const requestOptions = {
      method: 'GET',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      }
    };

    try {
      const response = await fetch(url, requestOptions);
      const data: StockDailyResponseData = await response.json();
      stockData.push(data);
    } catch (err) {
      throw err;
    }
    i++;
  }

  return stockData;
}
