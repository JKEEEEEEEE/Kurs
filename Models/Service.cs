using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
    public partial class Service
    {
        public int? IdServices { get; set; }

		public string Name_Services { get; set; }

		public decimal Price_Services { get; set; }

		//public virtual ICollection<Hotel> Hotels { get; } = new List<Hotel>();
	}
}