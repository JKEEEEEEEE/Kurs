using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
	public partial class TouristRoute
	{
		public int IdTouristRoutes { get; set; }

		public string NameTouristRoutes { get; set; }

		public string DescriptionTouristRoutes { get; set; }

		public string DurationTouristRoutes { get; set; } 

		public DateTime DateTouristRoutes { get; set; }

		public DateTime TimeTouristRoutes { get; set; }

		public int MaximumNumberTouristsTouristRoutes { get; set; }

		public int PhotoId { get; set; }

		public int PlacesVisitedId { get; set; }

		//public virtual ICollection<Country> Countries { get; } = new List<Country>();

		//public virtual Photo? Photo { get; set; }

		//public virtual PlacesVisited? PlacesVisited { get; set; }
	}
}