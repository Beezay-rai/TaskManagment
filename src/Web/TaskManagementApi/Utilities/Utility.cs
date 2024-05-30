using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementInfrastructure.Data;

namespace TaskManagementApi.Utilities
{
    public class Utility : IUtility
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly AdministratorDetail _adminDetail;

        public Utility(IConfiguration config, IOptions<AdministratorDetail> adminDetail)
        {
            _config = config;
            _adminDetail = adminDetail.Value;
        }

        public void GenerateRefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public string GenerateToken(Dictionary<string, object> UserDetails)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,UserDetails["Username"].ToString() ?? ""),
                new Claim(ClaimTypes.NameIdentifier,UserDetails["Email"].ToString() ?? ""),
                new Claim(ClaimTypes.Role,UserDetails["Roles"].ToString() ?? ""),
            };
            var tokenhandler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityToken(
                issuer: _config["JWTConfig:ValidIssuer"],
                audience: _config["JWTConfig:ValidAudience"],
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTConfig:SecretKey"].ToString() ?? "asd")), SecurityAlgorithms.HmacSha256)
                );


            tokenhandler.WriteToken(token);

            return tokenhandler.WriteToken(token);
        }



    }
}
