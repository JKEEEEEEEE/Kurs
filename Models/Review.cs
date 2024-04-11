using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
    public partial class Review
    {
        public int? IdReviews { get; set; }

        public int EvaluationReviews { get; set; }

        public string DescriptionReviews { get; set; } 

        public DateTime DateReviews { get; set; }

        public int UsersId { get; set; }

        //public virtual ICollection<Tour> Tours { get; } = new List<Tour>();

        //public virtual User? Users { get; set; }
    }
}