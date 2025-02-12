﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public int AddressId { get; set; } // klucz obcy do tabeli z adresem
        public virtual Address Address { get; set; } // referencja
        public virtual List<Dish> Dishes { get; set; }
}
}
