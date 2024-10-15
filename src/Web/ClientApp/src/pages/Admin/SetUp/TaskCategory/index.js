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

import MyModal from "../../../../components/Utilities/modal";
import { PuffLoader } from "react-spinners";

import MenuIcon from "@mui/icons-material/Menu";
import CollapseItem from "../../../../components/Utilities/collapseItem";
import DataTable from "../../../../components/Utilities/dataTable";

export default function Index() {
  const router = useRouter();
  const dispatch = useDispatch();
  const [taskCategoryList, setTaskCategoryList] = useState([]);
  const appState = store.getState().application;

  const [loading, setLoading] = useState(false);
  useEffect(() => {
    setLoading(true);
    const fetchData = async () => {
      try {
        const data = await taskCategoryService();

        setTaskCategoryList(data);
      } catch (error) {
        console.error("Failed to fetch tasks:", error);
      } finally {
        setLoading(false);
      }
    };
    fetchData();
  }, [dispatch]);


  const [open, setOpen] = useState(false);

  const handleModal = () => setOpen(!open);

  const [openIndex, setOpenIndex] = useState(false);
  const handleAction = (index) => {
    setOpenIndex((prevIndex) => (prevIndex === index ? null : index)); // Toggle open/close
  };

  const columns = [
    { header: "Id", accessor: "id" },
    { header: "Name", accessor: "name" },
    // { header: 'Action', accessor: 'action' },
  ];
  const addtionalHeading = () => {
    return <th>Action</th>;
  };

  const additionalTd = (index, data, openIndex, handleAction) => (
    <td>
      <div className="action relative inline-block">
        <button type="button" onClick={() => handleAction(index)}>
          <MenuIcon className="text-blue-700 hover:text-blue-300" />
        </button>

        <CollapseItem state={openIndex === index}>
          <ul className="py-3 absolute border rounded-md shadow-md bg-white top-3 right-8 w-44 box-decoration-slice">
            <li className="hover:bg-slate-300 px-4 py-3 w-full">
              <a
                href={`TaskCategory/edit/${data.id}`}
                title="Edit"
                className="flex font-semibold font-sans px-7"
              >
                <BorderColorOutlinedIcon className="size-5" />
                Edit
              </a>
            </li>
            <li className="hover:bg-slate-300 px-4 py-3 w-full">
              <a
                href="Detail"
                title="Detail"
                className="flex font-semibold font-sans px-7 text-blue-400"
              >
                <VisibilityOutlinedIcon className="size-5" />
                View
              </a>
            </li>
            <li className="hover:bg-slate-300 px-4 py-3 w-full">
              <a
                href="Delete"
                title="Delete"
                className="flex font-semibold font-sans px-7 text-red-400"
              >
                <DeleteOutlineOutlinedIcon className="size-5" />
                Delete
              </a>
            </li>
          </ul>
        </CollapseItem>
      </div>
    </td>
  );

  return (
    <>
      <p className="route text-blue-600 py-2 border px-3 mb-1 rounded-md">
        {router.pathname}
      </p>
      <MyModal open={open}>
        <h1>My custom Modal</h1>
      </MyModal>
      <div className={`${adminStyle.tableCover} md:h-[800px] lg:h-[800px] `}>
        <div className="additional flex justify-between p-2 pb-4 ">
          <section>
            <h4 className="font-bold text-lg">Task Categories</h4>
          </section>

          <a href="TaskCategory/create">
            <button type="button" className="btn btn-primary ">
              + Add
            </button>
          </a>
        </div>

        <DataTable
          columns={columns}
          data={taskCategoryList}
          additionalData={(index, row) =>
            additionalTd(index, row, openIndex, handleAction)
          }
          addtionalHeading={addtionalHeading}
        />
      </div>
    </>
  );
}
