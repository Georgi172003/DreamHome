﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHomeApp.Entites
{
    public class Status
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public ICollection<Apartament> Apartaments { get; set; }
      //  public ICollection<Basement> Basements { get; set; }
       // public ICollection<Garage> Garages { get; set; }
       // public ICollection<ParkingSpace> ParkingSpaces { get; set; }
       // public ICollection<Shop> Shops { get; set; }
    }
}
