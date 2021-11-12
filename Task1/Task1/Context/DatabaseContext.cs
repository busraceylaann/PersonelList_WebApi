using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Model;

namespace Task1.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);
        }
    }
}
