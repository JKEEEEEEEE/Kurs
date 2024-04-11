using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
    public partial class Payment
    {
        public int? IdPayments { get; set; }

        public decimal PricePayments { get; set; }

        public DateTime DatePayments { get; set; }

        public string StatusPayments { get; set; } 

        //public virtual ICollection<Tour> Tours { get; } = new List<Tour>();
    }
}