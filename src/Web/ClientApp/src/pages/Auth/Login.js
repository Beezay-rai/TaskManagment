import { Bounce, Flip, Slide, Zoom, toast } from "react-toastify";
import landscapeBG from "../../assests/login.jpg";
import { loginService } from "../../services/apiServices/auth/authService";
import loginCss from "../../styles/login.module.css";
import { useForm, onSubmitHandler } from "react-hook-form";
import { useRouter } from "next/router";
import { useSelector, useDispatch } from "react-redux";
import {
  setUserState,
  setIsLoading,
} from "../../services/stateService/redux/redux";
import Cookies from "js-cookie";

export default function login() {
  const dispatch = useDispatch();
  const router = useRouter();

  const { register, handleSubmit, formState } = useForm();

  const onSubmit = async (data) => {
    try {
      debugger
      let response = await loginService(data);
      dispatch(setIsLoading(true));
      if (response.status) {
        toast.success("Login successful!");
        response.data.isAuth = true;

        Cookies.set("auth_token", response.data.Token, { expires: 1 });
        dispatch(setUserState(response.data));
        router.push("/Admin/Dashboard");
      }
      else{
        toast.error("Login Failed, Please Try Again !")
      }
    } catch (ex) {
      toast.error("An error occurred during login. Please try again.");
    } finally {
      dispatch(setIsLoading(false));
    }
  };

  return (
    <div
      className="login-cover flex justify-center items-center"
      style={{
        backgroundImage: `url(${landscapeBG.src})`,
        backgroundSize: "cover",
        height: "100vh",
      }}
    >
      <div className="login-card  flex  justify-center flex-col  w-1/4  h-fit p-5 border-white border-x-2 border-y-2  rounded-3xl backdrop-blur-md ">
        <div className="login-header text-white " style={{ fontSize: "30px" }}>
          <h4 className="block text-center">Login</h4>
        </div>

        <div className="login-body p-6">
          <form onSubmit={handleSubmit(onSubmit)}>
            <div className={loginCss.formBody}>
              <div className={loginCss.inputGroup}>
                <input
                  width="100%"
                  className={loginCss.input}
                  type="text"
                  placeholder="Username"
                  {...register("Username")}
                />
              </div>
              <div className={loginCss.inputGroup}>
                <input
                  className={loginCss.input}
                  type="password"
                  placeholder="Password"
                  {...register("Password")}
                />
              </div>
              <div className={loginCss.btnGroup}>
                <button
                  className={`${loginCss.btn} ${loginCss.btnLogin}`}
                  type="submit"
                  disabled={formState.isSubmitting ? "disabled" : ""}
                >
                  {formState.isSubmitting ? "Submitting..." : "Login"}
                </button>
              </div>

              <div className="row">
                Not a member? <a className="text-blue-500 font-bold">Sign Up</a>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
