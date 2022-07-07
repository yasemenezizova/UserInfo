using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Data.Concrete.Mappings;
using UserProcess.Entity.Concrete;

namespace UserProcess.Data.Concrete.Contexts
{
    public class UserProcessContext:DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=PersonInfo4;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.Entity<Address>()
                 .HasOne(a => a.Person)
                 .WithOne(b => b.Address)
                 .HasForeignKey<Person>(b => b.AddressId);
        }
    }
}
