using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EfCoreExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreExample.Map
{

    public class PersonMap : IEntityTypeConfiguration<Person>
    {


        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.ToTable("People");


            builder.HasKey(x => x.PersonId);

            builder.Property(x => x.PersonId)
                .IsRequired();

            
            builder.Property(x => x.FistName)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("varchar(30)");

           
        }
    }

}