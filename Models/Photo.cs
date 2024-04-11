using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
    public partial class Photo
    {
        public int? IdPhoto { get; set; }

        public string NamePhoto { get; set; } 

        public string LinkPhoto { get; set; } 

        //public virtual ICollection<Hotel> Hotels { get; } = new List<Hotel>();

        //public virtual ICollection<Room> Rooms { get; } = new List<Room>();

        //public virtual ICollection<TouristRoute> TouristRoutes { get; } = new List<TouristRoute>();

        //public virtual ICollection<Tour> Tours { get; } = new List<Tour>();
    }
}