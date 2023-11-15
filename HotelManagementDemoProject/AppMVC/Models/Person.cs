using System.ComponentModel.DataAnnotations;

namespace AppMVC.Models
{
    public class Person
    {
        [Key] 
        
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public int IdNum { get; set; }
    }
}
