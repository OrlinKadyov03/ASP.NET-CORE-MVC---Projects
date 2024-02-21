using CarServiceShop.Models.Enum;

namespace CarServiceShop.ViewModels
{
    public class EditCarViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int EngineVolume { get; set; }
        public int Horsepower { get; set; }
        public EngineType EngineType { get; set; }
        public TransmisionType TransmisionType { get; set; }
        public string Color { get; set; }
        public CarCategory Category { get; set; }
        public string DescriptionProblem { get; set; }
        public string RegisterPlate { get; set; }
        public DateTime YearOfProduction { get; set; }
        public Drivetrain Drivetrain { get; set; }
        public int OwnerId { get; set; }
    }
}
