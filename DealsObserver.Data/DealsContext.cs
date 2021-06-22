﻿using Microsoft.EntityFrameworkCore;
using DealsObserver.Data.Models;

namespace DealsObserver.Data
{
    public partial class DealsContext : DbContext
    {
        public DealsContext(DbContextOptions<DealsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Deal> Deals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.ToTable("Deal");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnType("date");

                entity.Property(e => e.DealershipName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.VehicleName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
