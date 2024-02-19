using CarServiceShop.Models;

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
                            Address = new Address()
                            {
                                City = "Velingrad",
                                State = "Pazardjik",
                                Street = "Vubls2"
                            },
                            Owner = new Owner()
                            {
                                FirstName = "Ivan",
                                LastName = "Ivanov",
                            }


                         },
                        new Car()
                        {
                            Brand = "Mercedes",
                            Address = new Address()
                            {
                                City = "Velingrad",
                                State = "Pazardjik",
                                Street = "Vubls2"
                            },
                            Owner = new Owner()
                            {
                                FirstName = "Dragan",
                                LastName = "Ivanov",
                            }
                        },
                        new Car()
                        {
                            Brand = "Toyota",
                            Address = new Address()
                            {
                                City = "Velingrad",
                                State = "Pazardjik",
                                Street = "Vubls2"
                            },
                            Owner = new Owner()
                            {
                                FirstName = "Dido",
                                LastName = "Ivanov",
                            }

                        },
                        new Car()
                        {
                            Brand = "Mini",
                            Address = new Address()
                            {
                                City = "Velingrad",
                                State = "Pazardjik",
                                Street = "Vubls2"
                            },
                            Owner = new Owner()
                            {
                                FirstName = "Ioan",
                                LastName = "Ivanov",
                            }
                        }
                    }) ;
                    context.SaveChanges();
                }
            }
        }
    }
}