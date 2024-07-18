import { useDispatch } from "react-redux";
import LinkButton from "../../../components/common/linkButton";
import adminStyle from "../../../styles/Admin/style.module.css";
import { useForm } from "react-hook-form";
import { setIsLoading } from "../../../services/stateService/redux/redux";

export default function Create() {
  const { register, handleSubmit } = useForm();
  const dispatch = useDispatch();
  const onSubmit = (data) => {
    dispatch(setIsLoading(true));
    setTimeout(() => {
      debugger;
      dispatch(setIsLoading(false));
    }, 1000);
  };

  return (
    <>
      <div className="formCover bg-white shadow-md p-5 m-2 rounded-md">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="formBody">
            <div className="row">
              <div className="col-span-2 ">
                <div className={adminStyle.inputGroup}>
                  <label>Title</label>
                  <input placeholder="Title" {...register("title")} />
                </div>
              </div>

              <div className="col-span-2">
                <div className={adminStyle.inputGroup}>
                  <label>Test</label>
                  <input placeholder="inputbox" {...register("test")} />
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
