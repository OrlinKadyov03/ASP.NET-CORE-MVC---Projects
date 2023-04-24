using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OrCarsOriginal.Models.Enumerators;


namespace OrCarsOriginal.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        [EmailAddress]
        public string UploadedBy { get; set; }
        [MaxLength(20)]
        public string Telephone { get; set; }
       // [ForeignKey("BrandName")]
        [Display(Name = "Car Brand")]
        [Required]
        public CarBrand CBrand { get; set; }
        public State SState { get; set; }
        [MaxLength(150)]
        public string ImageLink { get; set; }
         //[MaxLength(2000)]
         //[MinLength(30)]
        [StringLength(2000,MinimumLength = 30,ErrorMessage = "Length must be between 30 and 2000!" )]
        public string Description { get; set; }
        [Range(1914,2030)]
        public int Year { get; set; }
        public Gears Gear { get; set; }
        public Fuels Fuel { get; set; }
        public int Km { get; set; }
        public NewUsed NewOrUsed { get; set; }
        public int EngineSize { get; set; }
        public Body BBody { get; set; }
        [Required]
        public Colour Color { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM}")]
        [Display(Name = "Posted On")]
        public DateTime InDate { get; set; }

    }
}
