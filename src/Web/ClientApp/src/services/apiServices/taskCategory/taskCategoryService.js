import { taskCategoryApi } from "../apiHelper";
import apiUrls from "../apiUrl";

export const taskCategoryService = async ()=>{
    let response = await taskCategoryApi(
        apiUrls.taskCategory.taskCategory.method,
        apiUrls.taskCategory.taskCategory.url
    );
    return response;
};