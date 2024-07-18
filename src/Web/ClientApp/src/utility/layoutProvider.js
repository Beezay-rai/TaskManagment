import { useRouter } from "next/router";
import AdminLayout from "../components/Admin/Layout/layout";
import UserLayout from "../components/User/Layout/layout";

const Layout = ({ children }) => {
  const router = useRouter();
  const { pathname } = router;

  let SelectedLayout;

  if (pathname.startsWith("/Admin")) {
    SelectedLayout = AdminLayout;
  } else if (pathname.startsWith("/User")) {
    SelectedLayout = UserLayout;
  } else {
    SelectedLayout = ({ children }) => <>{children}</>; // Default layout or no layout
  }

  return <SelectedLayout>{children}</SelectedLayout>;
};

export default Layout;
