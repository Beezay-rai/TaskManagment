import { useDispatch } from "react-redux";
import adminStyle from "../../../../../styles/Admin/style.module.css";
import { useForm } from "react-hook-form";
import { setIsLoading } from "../../../../../services/stateService/redux/redux";
import { yupResolver } from "@hookform/resolvers/yup";
import { ErrorMessage } from "@hookform/error-message";
import * as yup from "yup";
import { taskCategorySchema } from "../../../../../schemas/schema";
import {
  createTaskCategoryService,
  GetTaskCategoryServiceById,
  updateTaskCategoryService,
} from "../../../../../services/apiServices/taskCategory/taskCategoryService";
import { toast } from "react-toastify";
import { useRouter } from "next/router";
import { useEffect, useState } from "react";

export default function Edit() {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(taskCategorySchema),
  });
  const router = useRouter();
  const { id } = router.query;
  const dispatch = useDispatch();
  const [apiData, setApiData] = useState();

  useEffect(() => {
    const fetchData = async () => {
      if (id) {
        try {
          dispatch(setIsLoading(true));
          const  data  = await GetTaskCategoryServiceById(id);
          setApiData(data);
        } catch (error) {
          toast.error("Failed to fetch data");
        } finally {
          dispatch(setIsLoading(false));
        }
      }
    };

    fetchData();
  }, [dispatch,id]);


  const onSubmit = async (data) => {
    data.id=id;
    dispatch(setIsLoading(true));
    try {
      let response = await updateTaskCategoryService(data);
      if (response.status) {
        toast.success("Success !");
        router.push("../");
      } else {
        toast.error("Error occured !");
      }
    } catch {
      toast.error("Something Went Wrong !");
    } finally {
      dispatch(setIsLoading(false));
    }
  };

  return (
    <>
          <p className="route text-blue-600 py-2 border px-3 mb-1 rounded-md">
        {router.pathname.replace("[id]",id) }
      </p>
      <div className="formCover">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="mb-5">
            <h1 className="font-bold text-xl">+Edit Task Category </h1>
          </div>
          <div className="formBody">
            <div className="row">
              <div className="col-span-2 ">
                <div className={adminStyle.inputGroup}>
                <label className={adminStyle.formLabel}>Name</label>
                  <input
                    className={adminStyle.formInput}
                    placeholder="Name"
                    defaultValue={apiData?.name}
                    {...register("name")}
                  />
                  <ErrorMessage
                    errors={errors}
                    name="name"
                    as="span"
                    className={adminStyle.error}
                  />
                </div>
              </div>
            </div>
          </div>
          <div className="btn-group mt-6 ">
            <button type="submit" className="btn btn-success">
              Save
            </button>
            <a href="../">
              <button type="button" className="btn btn-danger">
                Cancel
              </button>
            </a>
          </div>
        </form>
      </div>
    </>
  );
}
