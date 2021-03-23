using BlueBlan.Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBlan.Infraestructura
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BlueBankContext>
    {
        public BlueBankContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<BlueBankContext>();

            var connectionString = "Data Source=GEDGONZ\\SQLEXPRESS;Initial Catalog=BlueBankDB; Integrated Security=True";

            builder.UseSqlServer(connectionString);

            return new BlueBankContext(builder.Options);
        }
    }
}

