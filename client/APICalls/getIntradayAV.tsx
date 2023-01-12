import { StockDailyResponseData } from '../utils/Models';

export default async function getIntradayAV(stockSymbol: string) {
  const url = `/api/stock/${stockSymbol}`;

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
    console.log(data);
    return data;
  } catch (err) {
    throw err;
  }
}
