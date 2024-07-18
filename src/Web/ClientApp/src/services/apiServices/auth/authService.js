import { authApi } from "../apiHelper";
import apiUrls from "../apiUrl";

export const loginService = async (data)=>{
    let response = await authApi(
        apiUrls.authenticate.login.method,
        apiUrls.authenticate.login.url,
        data
    );
    return response;
};