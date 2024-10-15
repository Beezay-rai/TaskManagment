import React, { useState } from "react";
import logo from "../../../assests/image.png";
import adminStyle from "../../../styles/Admin/style.module.css";
import DashboardSharpIcon from "@mui/icons-material/DashboardSharp";
import CalendarMonthOutlinedIcon from "@mui/icons-material/CalendarMonthOutlined";
import AssignmentOutlinedIcon from "@mui/icons-material/AssignmentOutlined";
import SettingsIcon from "@mui/icons-material/Settings";
import PersonAddIcon from "@mui/icons-material/PersonAdd";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowUpIcon from "@mui/icons-material/KeyboardArrowUp";
import { getuid } from "process";
import Image from 'next/image';

const menu = [
  {
    key: "1",
    title: "Dashboard",
    icon: <DashboardSharpIcon />,
    url: "/Admin/Dashboard",
  },
  {
    key: "2",
    title: "Task",
    icon: <AssignmentOutlinedIcon />,
    url: "/Admin/Task",
  },
  {
    key: "3",
    title: "Calendar",
    icon: <CalendarMonthOutlinedIcon />,
    url: "/Admin/Calendar",
  },
];

const configSection = [
  {
    title: "SetUp",
    icon: <SettingsIcon />,
    children: [
      {
        title: "User",
        icon: <PersonAddIcon />,
      },
      {
        title: "Category",
        icon: <PersonAddIcon />,
        url: "/Admin/SetUp/TaskCategory",
      },
    ],
  },
  {
    title: "Setting",
    icon: <SettingsIcon />,
    url: "/Admin/Settings",
  },
];

const SideBar = () => {
  const [isCollapsed, setIsCollapsed] = useState(true);

  const handleCollapse = () => {
    setIsCollapsed(!isCollapsed);
  };

  return (
    <div className={adminStyle.sideBar}>
      {/* Logo of Application */}
      <div className="logo p-5 ">
      <Image  src={logo.src}
          height="32"
          width="90"
          className="rounded-full"
          alt="Logo" />
      
      </div>

      <div className={adminStyle.sideBarMenu}>
        <div className="menu-section">
          <h3 className="font-semibold text-slate-400 p-3">Menu</h3>
          <ul className="flex flex-col gap-1">
            {menu.map(({ icon, title, url, key }) => (
              <li key={key} className="rounded-md p-2 hover:bg-gray-600">
                <a className="flex gap-2.5 font-medium" href={url}>
                  {icon}
                  {title}
                </a>
              </li>
            ))}
          </ul>
        </div>

        <hr className="my-4 font-extralight" />

        <div className="config-section">
          <h3 className="font-semibold text-slate-400 p-3">Configuration</h3>
          <ul className="flex flex-col gap-1">
            {configSection.map(({ title, icon, url, children }, index) => (
              <li key={`config-${index}`}>
                {children ? (
                  <>
                    <button
                      className="flex gap-2.5 font-medium w-full last-of-type:ml-auto"
                      type="button"
                      onClick={handleCollapse}
                    >
                      {icon} {title}
                      {isCollapsed ? (
                        <KeyboardArrowDownIcon className="ml-auto" />
                      ) : (
                        <KeyboardArrowUpIcon className="ml-auto" />
                      )}
                    </button>
                    <ul
                      key={`config-${index}`}
                      className={`${adminStyle.subItems} ${
                        isCollapsed
                          ? "hidden opacity-0 h-0"
                          : "block opacity-100 h-auto"
                      }`}
                    >
                      {children.map((child, childIndex) => (
                        <a
                          key={`child-link-${index}-${childIndex}`}
                          href={child.url}
                        >
                          <li
                            key={`child-${index}-${childIndex}`}
                            className="flex gap-2.5"
                          >
                            {child.icon}
                            {child.title}
                          </li>
                        </a>
                      ))}
                    </ul>
                  </>
                ) : (
                  <a className="flex gap-2.5 font-medium" href={url}>
                    {icon}
                    {title}
                  </a>
                )}
              </li>
            ))}
          </ul>
        </div>
      </div>
    </div>
  );
};

export default SideBar;
