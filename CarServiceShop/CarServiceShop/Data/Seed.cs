using CarServiceShop.Models;
using CarServiceShop.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace CarServiceShop.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
          {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Bmw",
                            Model = "E46",
                            EngineVolume = 3000,
                            Horsepower = 231,
                            EngineType = EngineType.Petrol,
                            TransmisionType = TransmisionType.Manual,
                            Category = CarCategory.Sedan,
                            DescriptionProblem = "Car has issues with overheating maybe it's the headgasket or it needs revision on all coolant components.",
                            RegisterPlate = "CW2221WS",
                            YearOfProduction = new DateTime(2003,1,1),
                            Drivetrain = Drivetrain.RWD,
                            Color = "Grey",
                            Owner = new Owner()
                            {
                                FirstName = "Ivan",
                                LastName = "Ivanov",
                            }


                         },
                        new Car()
                        {
                            Brand = "Mercedes",
                            Model = "W222",
                            EngineVolume = 5500,
                            Horsepower = 420,
                            EngineType = EngineType.Petrol,
                            TransmisionType = TransmisionType.Automatic,
                            Category = CarCategory.Sedan,
                            DescriptionProblem = "The car burns oil, has some leakeage under it.",
                            RegisterPlate = "A2221WS",
                            YearOfProduction = new DateTime(2013,12,1),
                            Drivetrain = Drivetrain.FOURWHEELDRIVE,
                            Color = "Black",
  
                        },
                        new Car()
                        {
                            Brand = "Toyota",
                            Model = "Yaris",
                            EngineVolume = 1200,
                            Horsepower = 75,
                            EngineType = EngineType.Petrol,
                            TransmisionType = TransmisionType.Manual,
                            Category = CarCategory.HatchBack,
                            DescriptionProblem = "Needs new brake supports and new brake pads.",
                            RegisterPlate = "CE2121WS",
                            YearOfProduction = new DateTime(2007,1,2),
                            Drivetrain = Drivetrain.FWD,
                            Color = "Red",


                        },
                        new Car()
                        {
                            Brand = "Mini",
                            Model = "S",
                            EngineVolume = 1600,
                            Horsepower = 116,
                            EngineType = EngineType.Petrol,
                            TransmisionType = TransmisionType.Manual,
                            Category = CarCategory.Coupe,
                            DescriptionProblem = "Car needs new clutch.",
                            RegisterPlate = "S3421SS",
                            YearOfProduction = new DateTime(2005,1,1),
                            Drivetrain = Drivetrain.FWD,
                            Color = "Blue",

                        }
                    });
                  } ;
                    context.SaveChanges();
                }
            }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Owner>>();
                string adminUserEmail = "orlinkadyov@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new Owner()
                    {
                        UserName = "orlin",
                        Email = adminUserEmail,
                        FirstName = "Orlin",
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                var userManagerO = serviceScope.ServiceProvider.GetRequiredService<UserManager<Owner>>();
                string adminUserEmailO = "veselinkadyov@gmail.com";

                var adminUserO = await userManager.FindByEmailAsync(adminUserEmailO);
                if (adminUserO == null)
                {
                    var newAdminUser = new Owner()
                    {
                        UserName = "veselin",
                        Email = adminUserEmailO,
                        FirstName = "Veselin",
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "Pionerska",
                            City = "Plovidv",
                            State = "Plovdiv"
                        }
                    };
                    await userManagerO.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManagerO.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "ivangalov@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new Owner()
                    {
                        UserName = "ivan",
                        Email = appUserEmail,
                        FirstName = "Ivan",
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
  
}