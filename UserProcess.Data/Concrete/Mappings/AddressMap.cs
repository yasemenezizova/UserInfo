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
    public class AddressMap :IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.City).HasColumnType("NVARCHAR(200)");
            builder.Property(a => a.AddressLine).IsRequired();
            builder.Property(a => a.AddressLine).HasColumnType("NVARCHAR(200)");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();

        }
    }
}
