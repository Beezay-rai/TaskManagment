import NavBar from "./navBar";
import adminStyle from "../../../styles/Admin/style.module.css";
import SideBar from "./sideBar";

export default function AdminLayout({ children }) {
  return (
    <div className="layout overflow-hidden min-h-fit bg-slate-100 flex  w-full ">
      <SideBar />
      <main className={adminStyle.main}>
        <NavBar />
        {children}
      </main>
    </div>
  );
}
