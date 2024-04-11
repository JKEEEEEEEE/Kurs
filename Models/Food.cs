using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
    public partial class Food
    {
        public int? IdFood { get; set; }

        public decimal PriceFood { get; set; }

        public string DishFood { get; set; } 

        public string DescriptionFood { get; set; } 

        //public virtual ICollection<Hotel> Hotels { get; } = new List<Hotel>();
    }
}