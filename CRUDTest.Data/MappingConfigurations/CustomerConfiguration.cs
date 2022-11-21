using CRUDTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Data.MappingConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.Property(c => c.Firstname)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Lastname)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.BankAccountNumber)
                .IsRequired()
                .HasColumnType("varchar(12)");
        }
    }
}
