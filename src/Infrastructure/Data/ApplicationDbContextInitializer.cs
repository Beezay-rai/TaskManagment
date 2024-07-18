using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementInfrastructure.Data.Identity;

namespace TaskManagementInfrastructure.Data
{

    public class ApplicationDbContextInitializer
    {
        private readonly ILogger<ApplicationDbContextInitializer> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly AdministratorDetail _adminDetail;
        private readonly string role;

        public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<UserRole> roleManager,IOptions<AdministratorDetail> adminDetail)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _adminDetail = adminDetail.Value;
            role = adminDetail.Value.Role;
        }

        public async Task SeedData()
        {
            try
            {
                await SeedAdministrator();


            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

            }
        }


        private async Task SeedAdministrator()
        {

            try
            {
                
                var roleCheck = await _roleManager.RoleExistsAsync(role);
                if (!roleCheck) 
                {
                    var adminstratorRole = new UserRole()
                    {
                        Name = _adminDetail.Role,
                        Description = "Adminstrator of the App",

                    };
                    await _roleManager.CreateAsync(adminstratorRole);
                }
                var checkExist = await _userManager.FindByEmailAsync(_adminDetail.Email);
                if (checkExist==null)
                {
                    var administrator = new ApplicationUser()
                    {
                        UserName = _adminDetail.Username,
                        AccessFailedCount = 0,
                        LockoutEnabled = false,
                        EmailConfirmed = true,
                        Email = _adminDetail.Email,
                    };
                    await _userManager.CreateAsync(administrator,_adminDetail.Password);
                    var a = await _userManager.AddToRoleAsync(administrator, _adminDetail.Role);
                }


            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Error while Seeding Adminstrator, Error Message:{ex.Message} ,DateTime :{DateTime.UtcNow}" );
            }

        }



    }

    public class AdministratorDetail
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }


}
