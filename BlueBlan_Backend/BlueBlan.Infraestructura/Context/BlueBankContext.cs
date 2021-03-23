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

    }
}
