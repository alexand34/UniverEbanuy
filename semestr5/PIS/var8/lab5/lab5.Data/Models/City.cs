using System;
using System.Collections.Generic;

namespace lab5.Data.Models
{
    public partial class City
    {
        public City()
        {
            Cinemas = new HashSet<Cinema>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Cinema> Cinemas { get; set; }
    }
}
