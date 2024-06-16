import { useSelector } from "react-redux";
import Layout from "../../../components/Admin/Layout/layout";

export default function index() {
  const user = useSelector((state) => state.user);
  const appState = useSelector((state) => state.application);

  return (
    <>
      <div className="card">
        Hy from admin  {user.Username}
      </div>
    </>
  );
}
