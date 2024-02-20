using CarServiceShop.Models;
using CarServiceShop.Models.Enum;

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
                  } ;
                    context.SaveChanges();
                }
            }
        }
   }