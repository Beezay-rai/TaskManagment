import { useDispatch } from "react-redux";
import adminStyle from "../../../styles/Admin/style.module.css";
import { useForm } from "react-hook-form";
import { setIsLoading } from "../../../services/stateService/redux/redux";
import { Priority_Level } from "../../../constants/enums";
import { createTaskService } from "../../../services/apiServices/task/taskService";

export default function Create() {
  const { register, handleSubmit } = useForm();
  const dispatch = useDispatch();
  const onSubmit = async (data) => {
    try{
      dispatch(setIsLoading(true))
      var response  = await createTaskService(data);

    }
    catch(ex){

    }
    finally{
      dispatch(setIsLoading(false))

    }
    
  };
  const priorityOptions = Object.entries(Priority_Level);

  return (
    <>
      <div className="formCover bg-white shadow-md p-5 m-2 rounded-md">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="mb-5">
            <h1 className="font-bold text-xl">+ Add Task</h1>
          </div>
          <div className="formBody">
            <div className={adminStyle.row}>
              
              <div className={adminStyle.inputGroup}>
                <label className={adminStyle.formLabel}>Name</label>
                <input  className={adminStyle.formInput} placeholder="Name" {...register("name")} />
              </div>
          
              <div className={adminStyle.inputGroup}>
                <label className={adminStyle.formLabel}>Category</label>
                <select className={adminStyle.formSelect}  {...register("taskCategoryId")} >
                  <option value={1}>1</option>
                </select>
              </div>

              <div className={adminStyle.inputGroup}>
                <label className={adminStyle.formLabel}>Priority Level</label>
                <select className={adminStyle.formSelect}  {...register("priorityLevel")}>
                  {priorityOptions.map(([key, value]) => {                    
                    return <option key={key} value={value}>{key}</option>;
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
