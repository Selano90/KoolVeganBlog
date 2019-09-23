using KoolVeganBlog.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KoolVeganBlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            try
            {
                var scope = host.Services.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                ctx.Database.EnsureCreated();

                var adminRole = new IdentityRole("Admin");
                if (!ctx.Roles.Any())
                {
                    //create a role
                    roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();

                }

                if (!ctx.Users.Any(u => u.UserName == "kool.vegane@gmail.com"))
                {
                    //create an admin
                    var adminUser = new IdentityUser
                    {
                        UserName = "kool.vegane@gmail.com",
                        Email = "kool.vegane@gmail.com"
                    };
                    var result = userMgr.CreateAsync(adminUser, "kvadmin19").GetAwaiter().GetResult();
                    //add role to user
                    userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();

                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
