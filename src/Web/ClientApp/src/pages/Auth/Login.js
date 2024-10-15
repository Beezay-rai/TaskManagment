import { Bounce, Flip, Slide, Zoom, toast } from "react-toastify";
import landscapeBG from "../../assests/login.jpg";
import { loginService } from "../../services/apiServices/auth/authService";
import loginCss from "../../styles/login.module.css";
import { useForm, onSubmitHandler } from "react-hook-form";
import { useRouter } from "next/router";
import { useSelector, useDispatch } from "react-redux";
import AccountCircleOutlinedIcon from "@mui/icons-material/AccountCircleOutlined";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import {
  setUserState,
  setIsLoading,
} from "../../services/stateService/redux/redux";
import Cookies from "js-cookie";
import { ClipLoader } from "react-spinners";
import { ErrorMessage } from "@hookform/error-message";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import MyHeader from "../../components/Utilities/header";

export default function Login() {
  const loginSchema = yup.object().shape({
    Username: yup
      .string()
      .email("Invalid Email Format")
      .required("Email is required !"),
    Password: yup.string().required("Password is required !"),
  });

  const dispatch = useDispatch();
  const router = useRouter();

  const {
    register,
    handleSubmit,setError,
    formState: { errors, isSubmitting },
  } = useForm({
    resolver: yupResolver(loginSchema),
  });

  const onSubmit = async (data) => {
    try {
      let response = await loginService(data);
      dispatch(setIsLoading(true));

      if (response.status) {
        response.data.isAuth = true;
        Cookies.set("auth_token", response.data.Token, { expires: 1 });
        dispatch(setUserState(response.data));
        router.push("/Admin/Dashboard");
      }
      else{
        setError("root",{
          type:"onChange",
          message:response.message
        })
      }
    } catch (ex) {
      setError("root",{
        type:"onChange",
        message:"Internal Error !"
      })
    } finally {
      dispatch(setIsLoading(false));
    }
  };

  return (
    <>
   

    <div
      className="login-cover flex justify-center items-center bg-slate-50"
      style={{
        // backgroundImage: `url(${landscapeBG.src})`,
        // backgroundSize: "cover",
        height: "100vh",
      }}
    >
      <div className={loginCss.loginCard}>
        <div
          className="login-header text-neutral-600 "
          style={{ fontSize: "30px" }}
        >
          <h4 className="block text-center">Login</h4>
        </div>

        <div className="login-body p-6">
          <form onSubmit={handleSubmit(onSubmit)}>
            <div className={loginCss.formBody}>
              <div className="form-group">
                <div className="input-group flex items-center">
                  <span>
                    <AccountCircleOutlinedIcon className="text-cyan-300" />
                  </span>
                  <input
                    width="100%"
                    className={`${
                      errors.Username ? loginCss.errorInput : loginCss.input
                    }`}
                    type="text"
                    placeholder="Username"
                    {...register("Username")}
                  />
                </div>
                <ErrorMessage
                  errors={errors}
                  name="Username"
                  as="span"
                  className="error"
                />
              </div>
              <div className="form-group">
                <div className="input-group flex items-center">
                  <span>
                    <LockOutlinedIcon className="text-cyan-300" />
                  </span>
                  <input
                    className={`${
                      errors.Password ? loginCss.errorInput : loginCss.input
                    }`}
                    type="password"
                    placeholder="Password"
                    {...register("Password")}
                  />
                </div>
                <ErrorMessage
                  errors={errors}
                  name="Password"
                  as="span"
                  className="error"
                />
              </div>
              <ErrorMessage
                name="root"
                errors={errors}
                as="span"
                className="error"
                message={errors?.root?.message}
              />

              <div className={loginCss.btnGroup}>
                <button
                  className={`${loginCss.btn} ${loginCss.btnLogin}`}
                  type="submit"
                  disabled={isSubmitting ? "disabled" : ""}
                >
                  {isSubmitting ? (
                    <ClipLoader loading={true} size={18} color="" />
                  ) : (
                    "Login"
                  )}
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
    </>
  );
}
