using System;
using System.Collections.Generic;

namespace lab5.Data.Models
{
    public partial class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
