import type { NextPage } from 'next';
import Header from './Header';
import Drawer from './Drawer';

const stocks: NextPage = () => {
  return (
    <div className="px-6">
      <Header />
      <Drawer />
      <div>Stocks</div>
    </div>
  );
};

export default stocks;
