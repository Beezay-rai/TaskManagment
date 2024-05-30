import adminStyle from "../../../styles/Admin/style.module.css";

export default function NavBar() {
  return (
    <div className={adminStyle.navBar}>
      <div className="searchBar">
        <input
          type="text"
          placeholder="search"
          style={{ outline: "none" }}
        ></input>
      </div>

      <div className="content"></div>
    </div>
  );
}
