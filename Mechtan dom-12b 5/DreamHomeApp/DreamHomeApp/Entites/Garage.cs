using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHomeApp.Entites
{
    public class Garage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 50)]
        public int Area { get; set; }
        [Required]
        [MaxLength(5)] 
        public string Number { get; set; }
        public int HouseId { get; set; }
        public virtual House House { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
