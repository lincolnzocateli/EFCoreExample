using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EfCoreExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreExample.Map
{

    public class ContactMap : IEntityTypeConfiguration<Contact>
    {


        public void Configure(EntityTypeBuilder<Contact> builder)
        {

            builder.ToTable("Contacts");


            builder.HasKey(x => x.ContactId);

            builder.Property(x => x.ContactId)
                .IsRequired();

            
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(x => x.Observation)
                .HasColumnType("varchar(100)");

            builder.OwnsOne(x => x.Address).Property(x => x.AddressType)
                .IsRequired()
                .HasColumnType($"varchar(20)")
                .HasColumnName("Type");

            builder.OwnsOne(x => x.Address).Property(x => x.Street)
                .IsRequired()
                .HasColumnType($"varchar(60)")
                .HasColumnName("Street");

            builder.OwnsOne(x => x.Address).Property(x => x.Neighborhood)
                .HasColumnType($"varchar(60)")
                .HasColumnName("Complement");

            builder.OwnsOne(x => x.Address).Property(x => x.City)
                .IsRequired()
                .HasColumnType($"varchar(60)")
                .HasColumnName("City");

            builder.OwnsOne(x => x.Address).Property(x => x.State)
                .IsRequired()
                .HasColumnType($"varchar(2)")
                .HasColumnName("State");

            builder.OwnsOne(x => x.Address).Property(x => x.Zip)
                .IsRequired()
                .HasColumnType($"varchar(8)")
                .HasColumnName("ZipCode");

            //(1:N)
            builder.HasOne(x => x.Person)
                .WithMany(c => c.Contacts)
                .HasForeignKey(x => x.ContactId)
                .OnDelete(DeleteBehavior.Restrict);



           builder.HasIndex(e => new
               {
                   e.Name,
                   e.Address.AddressType,
                   e.Address.Zip,
               }).HasName("IX_MyIndex")
               .IsUnique();

        }
    }

}