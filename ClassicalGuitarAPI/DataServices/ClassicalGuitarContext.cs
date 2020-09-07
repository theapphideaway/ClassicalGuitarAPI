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
        private const string ConnectionString = @"Server=tcp:192.168.0.21,1434;Initial Catalog=123;Persist Security Info=False;User ID=123;Password=123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

        public DbSet<Guitar> Guitar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
