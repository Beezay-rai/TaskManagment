import { taskCategoryApi } from "../apiHelper";
import apiUrls from "../apiUrl";

export const taskCategoryService = async ()=>{
    let response = await taskCategoryApi(
        apiUrls.taskCategory.taskCategory.method,
        apiUrls.taskCategory.taskCategory.url
    );
    return response;
};

export const createTaskCategoryService = async(data)=>{
    let response = await taskCategoryApi(
        apiUrls.taskCategory.createTaskCategory.method,
        apiUrls.taskCategory.createTaskCategory.url,
        data
    )
    return response;

}
export const GetTaskCategoryServiceById = async(data)=>{
    let response = await taskCategoryApi(
        apiUrls.taskCategory.taskCategoryById.method,
        apiUrls.taskCategory.taskCategoryById.url +"/"+data,
        null
    )
    return response;

}