import logo from "../../../assests/image.png";
import adminStyle from "../../../styles/Admin/style.module.css";
import DashboardSharpIcon from "@mui/icons-material/DashboardSharp";
const menu = [
  {
    title: "Dashboard",
    icon: <DashboardSharpIcon />,
  }
];

export default function SideBar() {
  return (
    <div className={adminStyle.sideBar}>
      <div className="logo p-5">
        <img
          src={logo.src}
          height="32"
          width="90"
          className="rounded-full"
          alt="Logo"
        ></img>
      </div>

      <div className="sidebar-menu text-white p-5">
        <div className="menu-section">
          <h3 className="font-semibold text-slate-400 p-3">Menu</h3>
          <ul className="flex flex-col gap-1">
            <li className="bg-gray-600 rounded-md p-2 hover:bg-gray-600">
              <a className="flex gap-2.5 font-medium  " href="#">
                <DashboardSharpIcon /> Dashboard
              </a>
            </li>
            {menu.map(({icon, title}) => {
              return (
                <>
                  <li className="rounded-md p-2 hover:bg-gray-600">
                    <a className="flex gap-2.5 font-medium  " href="#">
                      {icon}
                      {title}
                    </a>
                  </li>
                </>
              );
            })}
          </ul>
        </div>
      </div>
    </div>
  );
}
