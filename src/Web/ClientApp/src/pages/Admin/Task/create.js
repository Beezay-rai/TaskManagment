import { useDispatch } from "react-redux";
import adminStyle from "../../../styles/Admin/style.module.css";
import { useForm } from "react-hook-form";
import { setIsLoading } from "../../../services/stateService/redux/redux";
import { Priority_Level } from "../../../constants/enums";

export default function Create() {
  const { register, handleSubmit } = useForm();
  const dispatch = useDispatch();
  const onSubmit = (data) => {
   
  };
  const priorityOptions = Object.entries(Priority_Level);


  return (
    <>
      <div className="formCover bg-white shadow-md p-5 m-2 rounded-md">
        <form  onSubmit={handleSubmit(onSubmit)}>
          <div className="formBody">
            <div className={adminStyle.row}>
                <div className={adminStyle.inputGroup}>
                  <label>Title</label>
                  <input placeholder="Title" {...register("title")} />
                </div>

                <div className={adminStyle.inputGroup}>
                  <label>Test</label>
                  <input placeholder="inputbox" {...register("test")} />
                </div>
                <div className={adminStyle.inputGroup}>
                  <label>Priority Level</label>
                  <select >
                    {priorityOptions.map(([key, value])=>{
                      debugger
                      return(
                        <option>{value}</option>
                      )
                    })}
            
                  </select>
                </div>
            </div>
          </div>
          <div className="btn-group">
            <button type="submit" className="btn btn-success">
              Save
            </button>
       
          </div>
        </form>
      </div>
    </>
  );
}
