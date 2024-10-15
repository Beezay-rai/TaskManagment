import { useDispatch } from "react-redux";
import adminStyle from "../../../../styles/Admin/style.module.css";
import { useForm } from "react-hook-form";
import { setIsLoading } from "../../../../services/stateService/redux/redux";
import { yupResolver } from "@hookform/resolvers/yup";
import { ErrorMessage } from "@hookform/error-message";
import * as yup from "yup";
import { taskCategorySchema } from "../../../../schemas/schema";
import { createTaskCategoryService } from "../../../../services/apiServices/taskCategory/taskCategoryService";
import { toast } from "react-toastify";
import { useRouter } from "next/router";

export default function Create() {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(taskCategorySchema),
  });
  const router = useRouter();
  const dispatch = useDispatch();
  const onSubmit = async (data) => {
    dispatch(setIsLoading(true));
    try {
      let response = await createTaskCategoryService(data);
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
      <div className="formCover ">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="mb-5">
            <h1 className="font-bold text-xl">+ Add Task Category </h1>
          </div>
          <div className="formBody">
            <div className={adminStyle.row}>
              <div className={adminStyle.inputGroup}>
                <label className={adminStyle.formLabel}>Name</label>
                <input
                  className={adminStyle.formInput}
                  placeholder="Name"
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
          <div className="btn-group mt-6 ">
            <button type="submit" className="btn btn-success">
              Save
            </button>
            <a href="./">
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
