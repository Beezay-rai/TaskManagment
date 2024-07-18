import axios from "axios";
import { useSelector } from "react-redux";
import store from "../stateService/redux/redux";

// const baseUrl = "https://localhost:8001/api";
const baseUrl = "https://localhost:7131/api"; 

export const baseEndpointurls = {
  taskCategoryUrl: `${baseUrl}/Admin/TaskCategory`,
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

export const authApi = async (method, url, data) => {
  try {
    let response = await axios({
      method,
      url: `${baseEndpointurls.authenticateUrl}${url}`,
      data,
    });
    return response.data;
  } catch (ex) {
    return ex;
  }
};
