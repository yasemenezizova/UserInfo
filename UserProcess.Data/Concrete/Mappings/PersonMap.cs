using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Entity.Concrete;

namespace UserProcess.Data.Concrete.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(a => a.FirstName).IsRequired();
            builder.Property(a => a.FirstName).HasColumnType("NVARCHAR(50)");
            builder.Property(a => a.LastName).IsRequired();
            builder.Property(a => a.LastName).HasColumnType("NVARCHAR(50)");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
        }
    }
}
