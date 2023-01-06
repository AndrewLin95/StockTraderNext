import type { NextPage } from 'next';

const Header: NextPage = () => {
  return (
    <div className="py-12 flex flex-row justify-between">
      <div>Stock Trader Next</div>
      <div>Stocks</div>
      <div>Pages</div>
    </div>
  );
};

export default Header;
