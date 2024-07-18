import VisibilityOutlinedIcon from "@mui/icons-material/VisibilityOutlined";
import DeleteOutlineOutlinedIcon from "@mui/icons-material/DeleteOutlineOutlined";
import BorderColorOutlinedIcon from "@mui/icons-material/BorderColorOutlined";
import adminStyle from "../../../../styles/Admin/style.module.css";
import { useEffect, useState } from "react";
import { taskCategoryService } from "../../../../services/apiServices/taskCategory/taskCategoryService";
import { useRouter } from "next/router";
import { useDispatch, useSelector } from "react-redux";
import store, {
  setIsLoading,
} from "../../../../services/stateService/redux/redux";
import Pagination from "../../../../components/Utilities/pagination";
import { DataTable } from "../../../../components/common/dataTable";
import Link from "next/link";

export default function index() {
  const router = useRouter();
  const dispatch = useDispatch();
  const [taskList, setTaskList] = useState([]);
  const appState = store.getState().application;

  useEffect( () => {
    dispatch(setIsLoading(true));
    var data = fetchData().then((response)=>{

      setTaskList(response);
    })
    dispatch(setIsLoading(false));
  }, [router]);


  const fetchData = async()=>{
    var data =await taskCategoryService();
    return data;
  }


  //Pagination
  const [currentPage, setCurrentPage] = useState(1);
  const [itemPerPage, setItemPerPage] = useState(10);

  const currentItems = taskList;
  const paginate = (currentPage) => setCurrentPage(currentPage);

  const headers = ["Id", "Name"];

  return (
    <>
      <div className={adminStyle.tableCover}>
        <div className="additional flex justify-between p-2">
          <section>
            <h4 className="font-bold text-lg">Tasks</h4>
            <p className="route text-blue-600">{router.pathname}</p>
          </section>

          <a href="TaskCategory/Create">
            <button type="button" className="btn btn-primary ">
              + Add
            </button>
          </a>
        </div>

        {/* <DataTable headers={headers}>
what is this
        </DataTable> */}

        <table className={adminStyle.table}>
          <thead>
            <tr>
              <th width="10%">S.N</th>
              <th>Id</th>
              <th>Title</th>

              <th>Action</th>
            </tr>
          </thead>

          <tbody>
            {currentItems.length > 0 ? (
              currentItems.map((data, index) => {
                return (
                  <tr key={index}>
                    <td width="10%">{index + 1}</td>
                    <td>{data.id}</td>
                    <td>{data.name}</td>

                    <td>
                      <a href={`TaskCategory/Edit/${data.id}`} title="Edit">
                        <BorderColorOutlinedIcon className="size-5 text-green-400" />
                      </a>
                      <a href="Detail" title="Detail">
                        <VisibilityOutlinedIcon className="size-5 text-blue-400" />
                      </a>
                      <a href="Delete" title="Delete">
                        <DeleteOutlineOutlinedIcon className="size-5 text-red-400" />
                      </a>
                    </td>
                  </tr>
                );
              })
            ) : appState.isLoading ? (
              <tr>
                <td colSpan="5">Loading.... </td>
              </tr>
            ) : (
              <tr>
                <td colSpan="5">No Data</td>
              </tr>
            )}
          </tbody>
        </table>
        <Pagination
          totalItems={taskList.length}
          itemsPerPage={itemPerPage}
          paginate={paginate}
        />
      </div>
    </>
  );
}
