using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHomeApp.Entites
{
    public class House
    {
        public House()
        {
            this.Apartaments = new HashSet<Apartament>();
            this.Basements = new HashSet<Basement>();
            this.Garages = new HashSet<Garage>();
            this.ParkingSpaces = new HashSet<ParkingSpace>();
            this.Shops = new HashSet<Shop>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string Town { get; set; }
        public string Adress { get; set; }
        public int LevelsCount { get; set; }
        public string Image { get; set; }
        public DateTime RegistratedOn { get; set; }
        public ICollection<Apartament> Apartaments { get; set; }
        public ICollection<Basement> Basements { get; set; }
        public ICollection<Garage> Garages { get; set; }
        public ICollection<ParkingSpace> ParkingSpaces { get; set; }
        public ICollection<Shop> Shops { get; set; }
        


    }
}
