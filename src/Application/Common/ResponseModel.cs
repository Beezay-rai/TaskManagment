 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApplication.Common
{
    public class ErrorResponseModel
    {
        public string Message { get; set; }
        public List<string> ErrorDescription { get; set; }
    }

    public class ResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }

    public class LoginResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}
