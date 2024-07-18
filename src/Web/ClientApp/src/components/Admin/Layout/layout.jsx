import NavBar from "./navBar";
import adminStyle from "../../../styles/Admin/style.module.css";
import SideBar from "./sideBar";

export default function AdminLayout({ children }) {
  return (
    <div className="layout bg-slate-100 flex h-screen w-full ">
      <SideBar />
      <main className={adminStyle.main}>
        <NavBar />
        {children}
      </main>
    </div>
  );
}
