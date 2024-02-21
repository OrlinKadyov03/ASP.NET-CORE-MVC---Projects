using CarServiceShop.Models.Enum;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceShop.Models
{
    public class Car
    {
        [Key]
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
        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }  


    }
}
