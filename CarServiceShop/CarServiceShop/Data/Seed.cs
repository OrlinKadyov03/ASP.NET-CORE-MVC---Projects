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
                            Model = "E46",
                            EngineType = "Petrol 3.0",
                            TransmisionType = "Manual",
                            Color = "Grey",
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
                            Model = "W222",
                            EngineType = "Petrol 6.0",
                            TransmisionType = "Automatic",
                            Color = "Black",
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
                            Model = "Yaris",
                            EngineType = "Petrol 1.2",
                            TransmisionType = "Manual",
                            Color = "Red",
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
                            Model = "S",
                            EngineType = "Petrol 1.6",
                            TransmisionType = "Manual",
                            Color = "Blue",
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
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}