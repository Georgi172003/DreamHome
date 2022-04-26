using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHomeApp.Entites
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1,500)]
        public int Area { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public int HouseId { get; set; }
        public virtual House House { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
