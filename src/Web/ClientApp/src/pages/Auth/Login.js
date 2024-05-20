import landscapeBG from "../../assests/login.jpg";
import loginCss from "../../styles/login.module.css"
export default function login() {
  return (
    <div
      className="login-cover flex justify-center"
      style={{
        backgroundImage: `url(${landscapeBG.src})`,
        backgroundSize: "cover",
        height: "100vh",
      }}
    >
      <div className="login-card flex  justify-center flex-col  w-1/3  h-fit p-4 border-white border-x-2 border-y-2  rounded-3xl backdrop-blur-md ">
        <div className="login-header text-white " style={{ fontSize: "30px" }}>
          <h4 className="block text-center">Login</h4>
        </div>

        <div className="login-body">
          <form className="flex flex-col ">
            <div className={loginCss.inputGroup}>
              <input width="100%" className={loginCss.input}  type="text" placeholder="Username" />
            </div>
            <div className={loginCss.inputGroup}>
              <input className={loginCss.input}   type="password" placeholder="Password" />
            </div>
            <div className="button-group">
              <button type="button">Login</button>
              <button type="button">Sign Up</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
