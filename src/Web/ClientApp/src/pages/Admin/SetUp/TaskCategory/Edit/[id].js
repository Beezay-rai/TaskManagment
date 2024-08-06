import { useDispatch } from "react-redux";
import adminStyle from "../../../../../styles/Admin/style.module.css";
import { useForm } from "react-hook-form";
import { setIsLoading } from "../../../../../services/stateService/redux/redux";
import LinkButton from "../../../../../components/common/linkButton";
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
  }, [id]);
  const onSubmit = async (data) => {
    data.id=id;
    dispatch(setIsLoading(true));
    try {
      let response = await updateTaskCategoryService(data);
      if (response.status) {
        toast.success("Success !");
        router.push("./");
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
      <div className="formCover bg-white shadow-md p-5 m-2 rounded-md">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="formBody">
            <div className="row">
              <div className="col-span-2 ">
                <div className={adminStyle.inputGroup}>
                  <label>Name</label>
                  <input
                    placeholder="Name"
                    name="name"
                    {...register("name")}
                    defaultValue={apiData?.name}
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
          <div className="btn-group ">
            <button type="submit" className="btn btn-success">
              Save
            </button>
            <LinkButton
              className={"btn btn-primary"}
              content={"Cancel"}
              url={"./../"}
              type={"button"}
            />
          </div>
        </form>
      </div>
    </>
  );
}
