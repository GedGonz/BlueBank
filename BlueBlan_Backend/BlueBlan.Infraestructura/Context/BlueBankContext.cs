using BlueBlan.Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBlan.Infraestructura.Context
{
    public class BlueBankContext: DbContext
    {

        public BlueBankContext(DbContextOptions<BlueBankContext> options) :base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure Fluent api
            modelBuilder.Entity<Account>(entity =>
            {

                entity.Property(e => e.AccountId).ValueGeneratedOnAdd();
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId).HasColumnName("ID");

                entity.Property(e => e.Value).HasColumnType("DECIMAL(9,2)");
                entity.Property(e => e.Number).HasColumnType("VARCHAR(15)");

            });

            modelBuilder.Entity<Client>(entity =>
            {

                entity.Property(e => e.ClientId).ValueGeneratedOnAdd();
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("VARCHAR(30)");
                entity.Property(e => e.LastName).HasColumnType("VARCHAR(30)");

            });
        }

    }
}
