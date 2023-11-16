namespace OneToOneRealationShip.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
