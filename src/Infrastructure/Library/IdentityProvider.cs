using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManagementInfrastructure.Data.Identity;

namespace TaskManagementInfrastructure.Library
{
    public class IdentityProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityProvider(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> GetLoggedInApplicationUser()
        {
            var emailClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (emailClaim != null)
            {
                var user = await _userManager.FindByEmailAsync(emailClaim);
                if (user != null)
                {
                    return user;
                }

                throw new Exception("User not found!");
            }

            throw new Exception("Email claim not found!");
        }

    }
  

}
