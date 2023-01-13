import { useEffect, useState } from 'react';
import LineChart from '../../components/LineChart';
import getIntradayAV from '../../APICalls/getIntradayAV';
import { StockDailyResponseData } from '../../utils/Models';

const Details = () => {
  const intraDayDataInterface = {} as StockDailyResponseData[];
  const [intraDayData, setIntraDayData] = useState<StockDailyResponseData[]>(
    intraDayDataInterface
  );
  const [loading, setLoading] = useState(true);

  // API call to .net Server
  async function getIntradayData() {
    const _data = await getIntradayAV(['ibm', 'intc']);
    setIntraDayData(_data);
    setLoading(false);
  }

  useEffect(() => {
    getIntradayData();
  }, []);

  useEffect(() => {
    console.log(intraDayData);
  }, [intraDayData]);

  if (loading) {
    return null;
  }

  return (
    <div className="border border-yellow-500 w-full h-full overflow-auto">
      <div>Static stock tracker info</div>
      <div>main page contents</div>
      <div className="flex flex-row">
        {Object.entries(intraDayData).map(([key, value]) => {
          return <LineChart key={key} intraDayData={value} />;
        })}
      </div>
    </div>
  );
};

export default Details;
