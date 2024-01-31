using Microsoft.AspNetCore.Identity;
using StreetWorkoutWebApp.Models;
using System.Diagnostics;

namespace StreetWorkoutWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Parks.Any())
                {
                    context.Parks.AddRange(new List<Park>()
                    {
                        new Park()
                        {
                            Title = "Park for every age",
                            Image = "https://img.freepik.com/premium-photo/portrait-little-schoolgirl-girl-playground_493343-28198.jpg?w=900",
                            Description = "This is the park for kids in Bor,Serbia.",
                            Address = new Address()
                            {
                                Street = "Danila Kisa",
                                City = "Bor",
                                Country = "Serbia"
                            }
                         },
                        new Park()
                        {
                            Title = "Park with benches",
                            Image = "https://img.freepik.com/free-photo/woman-doing-dips-workout_158595-3268.jpg?w=900&t=st=1706717134~exp=1706717734~hmac=5460323825afddcf757ca0b03969a7427cc65ae8449c025eb3c2ac00076819d6",
                            Description = "Very good street workout park with benches for both rest and for workout",
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                Country = "NC"
                            }
                        },
                        new Park()
                        {
                            Title = "Park for young kids",
                            Image = "https://img.freepik.com/premium-photo/side-view-full-length-boy-hanging-from-monkey-bars-playground_1048944-1827469.jpg?w=900",
                            Description = "Park with slides, good for kids but also for adults looking to workout because of bars",
                            Address = new Address()
                            {
                                Street = "Vojislava Ilica",
                                City = "Belgrade",
                                Country = "Serbia"
                            }
                        },
                        new Park()
                        {
                            Title = "Professional park",
                            Image = "https://img.freepik.com/premium-photo/training-town-with-simulators-sports-ground_553043-928.jpg?w=826",
                            Description = "This is very advanced calisthenics park with everything a person needs for training",
                            Address = new Address()
                            {
                                Street = "25 Main St",
                                City = "Michigan",
                                Country = "NC"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "bokicodes@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "bokicodes",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Bor",
        //                    State = "Serbia"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
