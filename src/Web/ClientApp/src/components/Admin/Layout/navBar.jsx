import { Avatar } from "@mui/material";
import adminStyle from "../../../styles/Admin/style.module.css";
import NotificationsIcon from "@mui/icons-material/Notifications";
import LogoutIcon from "@mui/icons-material/Logout";
import SettingsRoundedIcon from "@mui/icons-material/SettingsRounded";
import AccountBoxOutlinedIcon from "@mui/icons-material/AccountBoxOutlined";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { resetAllState, resetState } from "../../../services/stateService/redux/redux";
import {  useRouter } from "next/router";
export default function NavBar() {
  const [showAvataritem, setShowAvatarItem] = useState(false);

  const router =useRouter()
  const toggleAvatarItem = () => {
    setShowAvatarItem(!showAvataritem);
  };
  const user = useSelector((state) => state.user);
  const dispatch = useDispatch();

  const handleLogOut = () => {
    dispatch(resetState());
    router.push("/Auth/Login")
    dispatch(resetAllState());
    
  };

  return (
    <div className={adminStyle.navBar}>
      <div className="searchBar">
        <input
          type="text"
          placeholder="Search"
          style={{ outline: "none" }}
        ></input>
      </div>

      <div className="content flex flex-row items-center gap-4">
        <NotificationsIcon />
        <button type="button" onClick={toggleAvatarItem}>
          <Avatar></Avatar>
        </button>
        {showAvataritem && (
          <div className=" flex flex-col absolute bg-white top-20 border border-slate-300 w-60 right-1 rounded-md transition-opacity ease-in duration-1000 ">
            <ul className="relative flex flex-col gap-5 p-6 border-b border-slate-300">
              <li>
                <AccountBoxOutlinedIcon /> My Profile
              </li>
              <li>
                <SettingsRoundedIcon />
                Account Settings
              </li>
            </ul>
            <button
              type="button"
              className="flex gap-4 px-6 py-4 hover:text-red-500 transition-colors duration-300"
              onClick={handleLogOut}
            >
              <LogoutIcon />
              Log Out
            </button>
          </div>
        )}
      </div>
    </div>
  );
}
