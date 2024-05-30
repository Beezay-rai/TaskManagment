import { ToastContainer } from "react-toastify";
import "../styles/global.css";
import "react-toastify/dist/ReactToastify.css";
import AdminLayout from "../components/Admin/Layout/layout";
import { useRouter } from "next/router";
import UserLayout from "../components/User/Layout/layout";

export default function MyApp({ Component, pageProps }) {
  const router = useRouter();
  let Layout;
  const pathname = router.pathname;

  if (pathname.startsWith("/Admin")) {
    Layout = AdminLayout;
  } else if (pathname.startsWith("/User")) {
    Layout = UserLayout;
  } else {
    Layout = ({ children }) => <>{children}</>; // Default layout or no layout
  }

  return (
    <Layout>
      <Component {...pageProps} />
      <ToastContainer />
    </Layout>
  );
}
