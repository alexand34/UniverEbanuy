namespace lab4.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Cinemas> Cinemas { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>()
                .HasMany(e => e.Cinemas)
                .WithRequired(e => e.Cities)
                .HasForeignKey(e => e.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);
        }
    }
}
