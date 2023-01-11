import { StockDailyResponseData } from '../utils/Models';

export default async function getIntradayAV() {
  const url = 'http://localhost:8080/api/stock';

  const requestOptions = {
    method: 'GET',
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json'
    }
  };

  try {
    const response = await fetch(url, requestOptions);
    const data = await response.json();
    console.log(data);
    return data;
  } catch (err) {
    throw err;
  }
}
