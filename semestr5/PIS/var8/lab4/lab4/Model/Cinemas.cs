namespace lab4.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cinemas
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual Cities Cities { get; set; }
    }
}
