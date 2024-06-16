import { Bounce, Flip, Slide, Zoom, toast } from "react-toastify";
import landscapeBG from "../../assests/login.jpg";
import { loginService } from "../../services/apiServices/auth/authService";
import loginCss from "../../styles/login.module.css";
import { useForm, onSubmitHandler } from "react-hook-form";
import { useRouter } from "next/router";
import { useSelector ,useDispatch} from "react-redux";
import { setUserState } from "../../services/stateService/redux/redux";

export default function login() {

  const onSubmitHandler = (data) => {
    console.log(data);
    alert(data);
  };

  const dispatch = useDispatch();

  const router = useRouter();

  const { register, handleSubmit, formState } = useForm();

  //Redux



  const onSubmit = (data) => {
    try {
      let response = loginService(data).then((apiResponse) => {
        
        if (apiResponse.status) {
          toast.success(apiResponse.message, {
            theme: "colored",
            transition: Flip,
            hideProgressBar: true,
            autoClose: 1000,
          });
          dispatch(setUserState(apiResponse.data))
          router.push("/Admin/Dashboard");
        } else {
          toast(apiResponse.message, {
            type: "error",
            theme: "colored",
            transition: Flip,
            hideProgressBar: true,
            autoClose: 1000,
          });
        }
      });
    } catch (ex) {}
  };

  return (
    <div
      className="login-cover flex justify-center"
      style={{
        backgroundImage: `url(${landscapeBG.src})`,
        backgroundSize: "cover",
        height: "100vh",
      }}
    >
      <div className="login-card flex  justify-center flex-col  w-1/3  h-fit p-5 border-white border-x-2 border-y-2  rounded-3xl backdrop-blur-md ">
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
                  className={` ${loginCss.btn} ${loginCss.btnLogin}`}
                  type="submit"
                >
                  Login
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
