using ClassicalGuitarAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicalGuitarAPI.DataServices
{
    public class ClassicalGuitarContext: DbContext
    {
        private const string ConnectionString = @"Server=tcp:192.168.0.13,1434;Initial Catalog=classical_guitars;Persist Security Info=False;User ID=ServerAuth;Password=Enter967;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

        public DbSet<Guitar> Guitar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
