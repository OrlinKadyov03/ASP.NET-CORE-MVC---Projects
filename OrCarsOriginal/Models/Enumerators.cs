using System.Drawing;

namespace OrCarsOriginal.Models
{
    public class Enumerators
    {
        public enum CarBrand : byte
        {
            Bmw = 1,
            Mercedes,
            VW,
            Audi,
            Seat
        }

        public enum State : byte
        {
            Pazardjik,
            Plovdiv,
            Sofia,
            Velingrad,
            Varna,
            Asenovgrad,
            Kardjali
        }


        public enum Gears : byte
        {
            Automatic,
            Manual
        }

        public enum Fuels : byte
        {
            Diesel,
            Petrol,
            LPG,
            PetrolLPG
        }
        public enum NewUsed : byte
        {
            New,
            Used
        }
        public enum Body : byte
        {
            Hetch,
            Sedan,
            Coupe,
            Touring
        }
        public enum Colour : byte
        {
            Black,
            White
        }

    }
}
