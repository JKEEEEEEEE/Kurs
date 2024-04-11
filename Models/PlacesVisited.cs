using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
    public partial class PlacesVisited
    {
        public int? IdPlacesVisited { get; set; }

        public string NamePlacesVisited { get; set; } 

        public string DescriptionPlacesVisited { get; set; } 

        //public virtual ICollection<TouristRoute> TouristRoutes { get; } = new List<TouristRoute>();
    }
}