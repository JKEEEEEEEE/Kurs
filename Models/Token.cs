using System;
using System.Collections.Generic;

namespace kursach_diplom_desctop.Models
{
    public partial class Token
    {
        public int? IdToken { get; set; }

        public string NameToken { get; set; }

        public DateTime DateTimeToken { get; set; }

        //public virtual ICollection<User> Users { get; } = new List<User>();
    }
}