using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManagementApi.Security
{
    public class MyAuthroize : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
