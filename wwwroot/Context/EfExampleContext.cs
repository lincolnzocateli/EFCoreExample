using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EfCoreExample.Map;
using EfCoreExample.Models;
using Microsoft.EntityFrameworkCore;


namespace EfCoreExample.Context
{

    public class EfCoreExampleContext : DbContext
    {

        public EfCoreExampleContext(DbContextOptions options)
            : base(options)
        {
        }


        
        public DbSet<Person> People { get; set; }
        public DbSet<Contact> Contacts { get; set; }
 
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(modelBuilder);


        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {

            var changes = base.SaveChangesAsync(cancellationToken);
            return await changes;

        }


    }

}


