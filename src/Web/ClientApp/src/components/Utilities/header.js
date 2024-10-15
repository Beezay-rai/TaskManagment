import Head from "next/head";
import { useRouter } from 'next/router';

const MyHeader =()=>{
    const router = useRouter();

    const pageTitle = router.pathname ==='/'?'Home': router.pathname.split('/').pop();


    return (
      <Head>
        <title> {pageTitle ? pageTitle + " | " : ""}TMS </title>
      </Head>
    );
}

export default MyHeader;