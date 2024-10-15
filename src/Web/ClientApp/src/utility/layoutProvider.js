import { useRouter } from "next/router";
import AdminLayout from "../components/Admin/Layout/layout";
import UserLayout from "../components/User/Layout/layout";

const DefaultLayout = ({ children }) => <>{children}</>;

DefaultLayout.displayName = "DefaultLayout";

const Layout = ({ children }) => {
  const router = useRouter();
  const { pathname } = router;

  let SelectedLayout;

  if (pathname.startsWith("/Admin")) {
    SelectedLayout = AdminLayout;
  } else if (pathname.startsWith("/User")) {
    SelectedLayout = UserLayout;
  } else {
    SelectedLayout = DefaultLayout; // Use the explicitly defined default layout
  }

  return <SelectedLayout>{children}</SelectedLayout>;
};

Layout.displayName = "Layout";

export default Layout;
