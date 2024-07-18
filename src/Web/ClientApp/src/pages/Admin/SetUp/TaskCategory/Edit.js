import { useDispatch } from "react-redux";
import adminStyle from "../../../../styles/Admin/style.module.css";
import { useForm } from "react-hook-form";
import { setIsLoading } from "../../../../services/stateService/redux/redux";
import LinkButton from "../../../../components/common/linkButton";
import { yupResolver } from "@hookform/resolvers/yup";
import { ErrorMessage } from "@hookform/error-message";
import * as yup from "yup";
import { taskCategorySchema } from "../../../../schemas/schema";
import { createTaskCategoryService } from "../../../../services/apiServices/taskCategory/taskCategoryService";
import { toast } from "react-toastify";
import { useRouter } from "next/router";

export default function Edit({id}) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(taskCategorySchema),
  });
  const router = useRouter();
  const {test}=router.query;
  const dispatch = useDispatch();
  const onSubmit = async (data) => {
    dispatch(setIsLoading(true));
    try {
      let response = await createTaskCategoryService(data);
      if (response.status) {
        toast.success("Success !");
        router.push("./");
      }
      else{
        toast.error("Error occured !")
      }
    } catch {
      toast.error("Something Went Wrong !");
    } finally {
      dispatch(setIsLoading(false));
    }
  };

  return (
    <>
    {id}
      <div className="formCover bg-white shadow-md p-5 m-2 rounded-md">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="formBody">
            <div className="row">
              <div className="col-span-2 ">
                <div className={adminStyle.inputGroup}>
                  <label>Name</label>
                  <input placeholder="Name" name="name" {...register("name")} />
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
              url={"./"}
              type={"button"}
            />
          </div>
        </form>
      </div>
    </>
  );
}
