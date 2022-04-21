using DreamHomeApp.Data;
using DreamHomeApp.Entites;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHomeApp.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);
            var data = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedStatuses(data);

            return app;
        }
        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>> ();
            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync
                    (user, "123456");
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
               
        }

        private static void SeedStatuses(ApplicationDbContext data)
        {
            if (data.Statuses.Any())
            {
                return;
            }
            data.Statuses.AddRange(new[]
            {
                new Status {StatusName="Sold"},
                new Status {StatusName="Available"},
                new Status {StatusName="Reserved "},
                
            });
            data.SaveChanges();
        }
    }
}
