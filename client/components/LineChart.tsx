import { Line } from 'react-chartjs-2';
import 'chart.js/auto';
import ibmData from './ibmdata.json';

interface stockData {
  [timePoint: string]: number;
}

// TODO: determine if i can change colors depending on value (green for positive, red for negative)
// TODO: destroy chart on unmount

const LineChart = () => {
  const labels = [''];

  // to serve
  // TODO: filter data so that it is only between market open and close
  const returnData = () => {
    const returnedData = Object.entries(ibmData['Time Series (5min)']).reduce(
      (obj: stockData, dataPoint) => {
        obj[dataPoint[0]] = parseFloat(dataPoint[1]['1. open']);
        return obj;
      },
      {}
    );
    return returnedData;
  };

  let _data = returnData();
  console.log(_data);

  const data = {
    labels,
    datasets: [
      {
        label: 'Dataset 1', // to dynamically fill
        data: _data,
        borderColor: 'rgb(255, 99, 132)',
        backgroundColor: 'rgba(255, 99, 132, 0.5)'
      }
    ]
  };

  const options = {
    responsive: true,
    scales: {
      x: {
        display: false
      }
    },
    plugins: {
      legend: {
        display: false
      },
      title: {
        display: true,
        text: 'IBM Data' // to serve
      }
    }
  };

  return (
    <div>
      {/* datasetIdKey to set */}
      <Line datasetIdKey="1" data={data} options={options} />
    </div>
  );
};

export default LineChart;
