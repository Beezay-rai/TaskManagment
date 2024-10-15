import { taskApi } from "../apiHelper";
import apiUrls from "../apiUrl";

export const taskService = async ()=>{
    let response = await taskApi(
        apiUrls.task.task.method,
        apiUrls.task.task.url
    );
    return response;
};

export const createTaskService = async(data)=>{
    let response = await taskApi(
        apiUrls.task.createTask.method,
        apiUrls.task.createTask.url,
        data
    )
    return response;

}

export const updateTaskService = async(data)=>{
    let response = await taskApi(
        apiUrls.task.editTask.method,
        apiUrls.task.editTask.url,
        data
    )
    return response;

}

export const GetTaskServiceById = async(data)=>{
    let response = await taskApi(
        apiUrls.task.taskById.method,
        apiUrls.task.taskById.url +"/"+data,
        null
    )
    return response;

}