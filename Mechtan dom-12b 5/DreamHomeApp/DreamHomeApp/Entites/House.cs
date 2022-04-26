using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)] 
        public string Town { get; set; }
        
        [Required]
        [MaxLength(30)] 
        public string Adress { get; set; }
        [Required]
        [Range(1,12)]
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
