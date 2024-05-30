import axios from "axios";



const baseUrl = "https://localhost:7131/api";

export const baseEndpointurls = {
  taskCategoryUrl: `${baseUrl}/Admin/TaskCategory`,
  authenticateUrl:`${baseUrl}/Authenticate`
};

export const taskCategoryApi = async (method, url, data) => {
  try {
    let response = await axios({
      method,
      url: `${baseEndpointurls.taskCategoryUrl}${url}`,
      data,
    });

    return response.data;
  } 
  catch (exception) {
    return exception;
  }
};

export const authApi = async (method,url,data)=>{
  try{
    let response = await axios({
      method,
      url:`${baseEndpointurls.authenticateUrl}${url}`,
      data
    });
    return response.data;

  }
  catch(ex){
    return ex
  }
}
