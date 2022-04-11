using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHomeApp.Entites
{
    public class Apartament
    {
        [Key]
        public int Id { get; set; }
        public string  Number { get; set; }
        public int  Area { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        [Required]
        public int HouseId { get; set; }
        public virtual House House { get; set; }
        public string Image { get; set; }
        [Required]
        
        public int Level { get; set; }
        public int CountRooms { get; set; }
        public int CountBath { get; set; }
        public bool Closet { get; set; }
        public bool Wardrobe { get; set; }
        public string Exhibition { get; set; }


    }
}
