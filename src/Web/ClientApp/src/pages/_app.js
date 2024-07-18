import { ToastContainer } from "react-toastify";
import "../styles/global.css";
import "react-toastify/dist/ReactToastify.css";
import AdminLayout from "../components/Admin/Layout/layout";
import { useRouter } from "next/router";
import UserLayout from "../components/User/Layout/layout";
import { Provider, useDispatch } from "react-redux";
import store, { persistor } from "../services/stateService/redux/redux";
import { PersistGate } from "redux-persist/integration/react";
import Loader from "../components/Utilities/loader";
import { useSelector } from "react-redux";
import { useEffect } from "react";
import Layout from "../utility/layoutProvider";
const MyApp = ({ Component, pageProps }) => {
  return (
    <Provider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <LayoutWrapper
          Layout={Layout}
          Component={Component}
          pageProps={pageProps}
        />
      </PersistGate>
    </Provider>
  );
};

const LayoutWrapper = ({ Layout, Component, pageProps }) => {
  const isLoading = useSelector((state) => state.application.isLoading);

  return (
    <Layout>
      <ToastContainer />
      <Component {...pageProps} />
      <Loader isLoading={isLoading} />
    </Layout>
  );
};

export default MyApp;
