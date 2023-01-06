import type { NextPage } from 'next';
import Head from 'next/head';
import Link from 'next/link';

const Home: NextPage = () => {
  return (
    <div className="flex min-h-screen flex-col items-center justify-center py-2 ">
      <Head>
        <title>Stock Trader Next</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <div>
        <Link href="/stocks">Stocks</Link>
      </div>
    </div>
  );
};

export default Home;
