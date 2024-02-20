using CarServiceShop.Models.Enum;
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
        public string EngineType { get; set; }
        public string TransmisionType { get; set; }
        public string Color { get; set; }
        public DateTime YearOfProduction { get; set; }
        public Drivetrain Drivetrain { get; set; }
        public Owner Owner { get; set; }
        public Address Address { get; set; }    


    }
}
