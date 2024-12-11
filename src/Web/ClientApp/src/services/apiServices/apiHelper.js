import axios from "axios";
import { useSelector } from "react-redux";
import store from "../stateService/redux/redux";

// const baseUrl = "https://localhost:8001/api";
const baseUrl = "https://localhost:7131/api"; 

export const baseEndpointurls = {
  taskCategoryUrl: `${baseUrl}/Admin/TaskCategory`,
  taskUrl: `${baseUrl}/Admin/TaskEntity`,
  authenticateUrl: `${baseUrl}/Authenticate`,
};

const token = store.getState().user.Token;

export const taskCategoryApi = async (method, url, data) => {
  try {
    let response = await axios({
      method,
      url: `${baseEndpointurls.taskCategoryUrl}${url}`,
      headers: {
        Authorization: `Bearer ${token}`,
      },
      data,
    });

    return response.data;
  } catch (exception) {
    return exception;
  }
};


export const taskApi = async (method, url, data) => {
  try {
    let response = await axios({
      method,
      url: `${baseEndpointurls.taskUrl}${url}`,
      headers: {
        Authorization: `Bearer ${token}`,
      },
      data,
    });

    return response.data;
  } catch (exception) {
    return exception;
  }
};





export const authApi = async (method, url, data) => {
  try {
    let response = await axios({
      method,
      url: `${baseEndpointurls.authenticateUrl}${url}`,
      data,
    });
    return response.data;
  } catch (error) {
    if(!error.response){
      return  {
        status:false,
        message:"Network Error !"
      }
    }
    else{
        return error.response.data
    }

  }
};

// catch (error) {
//   if (!error.response) {
//     // Network error occurred
//     console.error('Network error:', error);
//   } else {
//     // The server responded with a status other than 200 range
//     console.error('Error response:', error.response);
//   }
// }
