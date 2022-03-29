using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHomeApp.Entites
{
    public class Garage
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public string Number { get; set; }
        public int HouseId { get; set; }
        public virtual House House { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
