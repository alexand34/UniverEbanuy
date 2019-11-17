namespace lab4.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cities
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cities()
        {
            Cinemas = new HashSet<Cinemas>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Population { get; set; }
        public decimal Area { get; set; }

        public int CountryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cinemas> Cinemas { get; set; }

        public virtual Countries Countries { get; set; }
    }
}
