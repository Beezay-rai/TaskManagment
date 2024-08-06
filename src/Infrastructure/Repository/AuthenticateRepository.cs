using TaskManagementApplication.Common;
using TaskManagementApplication.Interfaces;
using TaskManagementApplication.Models;
using Microsoft.AspNetCore.Identity;
using TaskManagementInfrastructure.Data.Identity;
namespace TaskManagementInfrastructure.Repository
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateRepository(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginResponseModel> Login(LoginModel model)
        {

            var response = new LoginResponseModel();
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Username);
                if (user != null)
                {
                    var checkPass = await _userManager.CheckPasswordAsync(user, model.Password);

                    if (checkPass)
                    {
                        var login = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                        response.Status = login.Succeeded;
                        response.Message = "Login Successfully !";
                        var userRoles = await _userManager.GetRolesAsync(user);
                        response.Data["Roles"] = userRoles;
                        response.Data["Username"] = user.UserName ?? "Not Defined";
                        response.Data["Email"] = model.Username;

                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Invalid Username or Password !";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "Invalid Username or Password !";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }

            return response;
        }

        public Task<ResponseModel> SignUp(SignUpModel model)
        {
            throw new NotImplementedException();
        }
    }
}
