import { ToastContainer } from "react-toastify";
import "../styles/global.css";
import "react-toastify/dist/ReactToastify.css";
import { Provider } from "react-redux";
import store, { persistor } from "../services/stateService/redux/redux";
import { PersistGate } from "redux-persist/integration/react";
import Loader from "../components/Utilities/loader";
import { useSelector } from "react-redux";
import Layout from "../utility/layoutProvider";
import "animate.css";
import MyHeader from "../components/Utilities/header";

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
      <MyHeader/>
      <Component {...pageProps} />
      <Loader isLoading={isLoading} />
    </Layout>
  );
};

export default MyApp;
