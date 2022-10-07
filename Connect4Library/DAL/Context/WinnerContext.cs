using Connect4Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Library.DAL.Context
{
    public class WinnerContext:DbContext
    {
        public DbSet<Winner> Winners { get; set; }
        public WinnerContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Winner>().Property(w => w.Id).ValueGeneratedOnAdd();
        }
    }
}
