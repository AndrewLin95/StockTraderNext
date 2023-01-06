import type { NextPage } from 'next';
import Header from './Header';
import Drawer from './Drawer';
import Details from './Details';

const stocks: NextPage = () => {
  return (
    <div className="px-6 h-screen overflow-hidden dark:bg-slate-800 dark:text-gray-50 bg-white text-gray-800 ">
      <Header />
      <div className="flex flex-row h-full">
        <Drawer />
        <Details />
      </div>
    </div>
  );
};

export default stocks;
