import LineChart from '../../components/LineChart';
import Chart from 'chart.js/auto';
import ibmData from '../../components/ibmdata.json';

const Details = () => {
  // const returnData = () => {
  //   let obj = {};
  //   console.log(ibmData);
  //   for (const key in ibmData['Time Series (5min)']) {
  //     console.log(key);
  //   }
  //   return obj;
  // };

  // returnData();

  return (
    <div className="border border-yellow-500 w-full h-full">
      <div>Static stock tracker info</div>
      <div>main page contents</div>
      <LineChart />
    </div>
  );
};

export default Details;
