import { FC } from 'react';
import { Line } from 'react-chartjs-2';
import 'chart.js/auto';
import { StockDailyResponseData } from '../utils/Models';

// TODO: determine if i can change colors depending on value (green for positive, red for negative)
// TODO: destroy chart on unmount

interface Props {
  intraDayData: StockDailyResponseData;
}

const LineChart: FC<Props> = ({ intraDayData }) => {
  const labels = [''];

  const data = {
    labels,
    datasets: [
      {
        label: intraDayData.label,
        data: intraDayData.stockData,
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
        text: intraDayData.title
      }
    }
  };

  return (
    <div>
      <Line
        datasetIdKey={intraDayData.datasetIdKey}
        data={data}
        options={options}
      />
    </div>
  );
};

export default LineChart;
