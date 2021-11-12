using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi_personelDemo.Model;

namespace webApi_personelDemo.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Personel> Personels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>()
                .HasKey(p => p.Id);
        }
    }
}
