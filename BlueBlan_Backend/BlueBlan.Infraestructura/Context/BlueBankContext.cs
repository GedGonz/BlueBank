using BlueBlan.Dominio.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBlan.Infraestructura.Context
{
    public class BlueBankContext: IdentityDbContext<User>
    {

        public BlueBankContext(DbContextOptions<BlueBankContext> options) :base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<AccountMove> AccountMoves { get; set; }

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

                entity.Property(e => e.ValueInit).HasColumnType("DECIMAL(9,2)");
                entity.Property(e => e.Valuecurrent).HasColumnType("DECIMAL(9,2)");
                entity.Property(e => e.Number).HasColumnType("VARCHAR(15)");
                entity.Property(e => e.State).HasDefaultValueSql("(1)");

            });

            modelBuilder.Entity<Client>(entity =>
            {

                entity.Property(e => e.ClientId).ValueGeneratedOnAdd();
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("VARCHAR(30)");
                entity.Property(e => e.LastName).HasColumnType("VARCHAR(30)");

            });

            modelBuilder.Entity<AccountMove>(entity =>
            {

                entity.Property(e => e.AccountMoveId).ValueGeneratedOnAdd();
                entity.HasKey(e => e.AccountMoveId);

                entity.Property(e => e.AccountMoveId).HasColumnName("ID");

                entity.Property(e => e.DateMove).HasColumnType("DateTime");

                entity.Property(e => e.DateMove).HasDefaultValueSql("(getdate())");

            });

            modelBuilder.Entity<User>(entity =>
            {

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);

            });
            this.SeedRoles(modelBuilder);
            this.SeedUsers(modelBuilder);
            this.SeedUserRoles(modelBuilder);
        }
        //Seed Data
        private void SeedUsers(ModelBuilder builder)
        {
            User user = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            var passworsHas=passwordHasher.HashPassword(user, "Admin123*");
            user.PasswordHash = passworsHas;
            builder.Entity<User>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "HR", ConcurrencyStamp = "2", NormalizedName = "Human Resource" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }

    }
}
