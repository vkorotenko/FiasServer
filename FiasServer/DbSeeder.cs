using System.Linq;
using System.Threading.Tasks;
using FiasServer.Data;
using FiasServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FiasServer
{
    public class DbSeeder
    {
        private static UserManager<ApplicationUser> _userManager;
        private const string adminRole = "Administrator";
        private const string userRole = "User";
        private static ApplicationDbContext _ctx;
        private RoleManager<ApplicationRole> _roleManager;

        public DbSeeder(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _ctx = ctx;
            _roleManager = roleManager;
        }

        public void Seed()
        {
            CheckRoles().Wait();
            AddUserToAdminRole().Wait();
        }

        public async Task AddUserToAdminRole()
        {
            var user = await _userManager.FindByEmailAsync("koroten@ya.ru");
            if (user != null)
            {
                if (!await _userManager.IsInRoleAsync(user, adminRole))
                {
                    await _userManager.AddToRoleAsync(user, adminRole);
                }
            }

        }
        public async Task CheckRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if (roles.All(x => x.Name != adminRole))
            {
                await _roleManager.CreateAsync(new ApplicationRole() { Name = adminRole });
            }
            if (roles.All(x => x.Name != userRole))
            {
                await _roleManager.CreateAsync(new ApplicationRole(){Name = userRole});
            }
        }
    }
}
