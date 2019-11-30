using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ARoom.Common.Model
{
    public partial class aRoomContext : DbContext
    {
        public aRoomContext()
        {
        }

        public aRoomContext(DbContextOptions<aRoomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WarehouseZone> WarehouseZones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Shelving)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categories_WarehouseZones");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.Characteristics).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ShortCharacteristics).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Goods_Categories");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            modelBuilder.Entity<WarehouseZone>(entity =>
            {
                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
