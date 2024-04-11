using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
    public partial class Tour
    {
        public int? IdTours { get; set; }

        public string DescriptionTours { get; set; } 

        public string TypeTours { get; set; } 

        public decimal PriceTours { get; set; }

        public DateTime StartDateTours { get; set; }

        public DateTime EndDateTours { get; set; }

        public string ReservationNumberTours { get; set; } 

        public string BookingDateTours { get; set; } 

        public string BookingStatusTours { get; set; } 

        public int ReviewsId { get; set; }

        public int PaymentsId { get; set; }

        public int UsersId { get; set; }

        public int PhotoId { get; set; }

        public int CountryId { get; set; }

        //public virtual Country? Country { get; set; }

        //public virtual Payment? Payments { get; set; }

        //public virtual Photo? Photo { get; set; }

        //public virtual Review? Reviews { get; set; }

        //public virtual User? Users { get; set; }
    }
}