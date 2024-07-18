using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Common;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Interfaces
{
    public interface IAuthenticateRepository
    {

        Task<LoginResponseModel> Login(LoginModel model);
        Task<ResponseModel> SignUp(SignUpModel model);
        
    }
}
