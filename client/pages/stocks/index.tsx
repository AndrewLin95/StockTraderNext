import type { NextPage } from 'next';
import Header from './Header';
import Drawer from './Drawer';

const stocks: NextPage = () => {
  return (
    <div className="px-6 overflow-hidden dark:bg-slate-800 dark:text-gray-50 bg-white text-gray-800">
      <Header />
      <Drawer />
      <div>Stocks</div>
    </div>
  );
};

export default stocks;
