import VisibilityOutlinedIcon from "@mui/icons-material/VisibilityOutlined";
import DeleteOutlineOutlinedIcon from "@mui/icons-material/DeleteOutlineOutlined";
import BorderColorOutlinedIcon from "@mui/icons-material/BorderColorOutlined";
import adminStyle from "../../../styles/Admin/style.module.css";
import { useEffect, useState } from "react";
import { taskService } from "../../../services/apiServices/task/taskService";
import { useDispatch } from "react-redux";
import { setIsLoading } from "../../../services/stateService/redux/redux";


export default function Index() {
  const dispatch = useDispatch();
  const [taskList, setTaskList] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        // dispatch(setIsLoading(true));
        const data = await taskService();

        setTaskList(data);
      } catch (error) {
        console.error("Failed to fetch tasks:", error);
      } finally {
        // dispatch(setIsLoading(false));
      }
    };
    fetchData();
  }, [dispatch]);
  return (
    <>
      <div className={adminStyle.tableCover}>
        <div className="additional flex justify-between p-2">
          <section>
            <h4 className="font-bold text-lg">Tasks</h4>
            <p className="route text-blue-600">/Admin/Task</p>
          </section>

          <a href="Task/create">
            <button type="button" className="btn btn-primary ">
              + Add
            </button>
          </a>
        </div>
        <table className={adminStyle.adminDataTable}>
          <thead>
            <tr>
              <th>S.N</th>
              <th>Id</th>
              <th>Title</th>
              <th>Description</th>
              <th>Priority</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {taskList.length<0?
             <tr> <td>Loading ..</td></tr>:
             taskList.map((data, index) => (
              <tr key={data}>
                <td>{index + 1}</td>
                <td>{data.id}</td>
                <td>{data.name}</td>
                <td>For Testing</td>
                <td>Low</td>
                <td>
                  <a href="Edit" title="Edit">
                    <BorderColorOutlinedIcon className="size-5 text-green-400" />
                  </a>
                  <a href="Detail" title="Detail">
                    <VisibilityOutlinedIcon className=" size-5 text-blue-400" />
                  </a>
                  <a href="Delete" title="Delete">
                    <DeleteOutlineOutlinedIcon className="size-5 text-red-400" />
                  </a>
                </td>
              </tr>
            ))
            }
            {/* {taskList.map((data, index) => (
              <tr key={data}>
                <td>{index + 1}</td>
                <td>{data.id}</td>
                <td>{data.name}</td>
                <td>For Testing</td>
                <td>Low</td>
                <td>
                  <a href="Edit" title="Edit">
                    <BorderColorOutlinedIcon className="size-5 text-green-400" />
                  </a>
                  <a href="Detail" title="Detail">
                    <VisibilityOutlinedIcon className=" size-5 text-blue-400" />
                  </a>
                  <a href="Delete" title="Delete">
                    <DeleteOutlineOutlinedIcon className="size-5 text-red-400" />
                  </a>
                </td>
              </tr>
            ))} */}
          </tbody>
        </table>
      </div>
    </>
  );
}
