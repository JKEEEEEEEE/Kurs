using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
    public partial class City
    {
		public int? IdCity { get; set; }

		public string NameCity { get; set; }
		public string HotelName { get; set; }

		public int? HotelId { get; set; }

		//public virtual Hotel? Hotel { get; set; }
	}
}