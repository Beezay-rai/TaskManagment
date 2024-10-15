import { Html, Head, Main, NextScript } from "next/document";
export default function Document() {
  return (
    <Html lang="en">
      <Head>
        <link rel="icon" href="/favicon.ico" />
        <link
          href="https://fonts.googleapis.com/css2?family=League+Gothic&display=swap"
          rel="stylesheet"
        />
      </Head>
      <body>
        <Main />
      </body>
      <NextScript />
    </Html>
  );
}
