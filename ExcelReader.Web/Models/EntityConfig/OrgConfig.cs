using ExcelReader.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Web.Models.EntityConfig
{
    public class OrgConfig : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Organisation> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.OrgNumber)
              .IsRequired()
              .HasMaxLength(10);

            builder.Property(x => x.Name)
              .IsRequired()
              .HasMaxLength(250);
            builder.Property(x => x.Address1)
             .IsRequired()
             .HasMaxLength(1000);
            builder.Property(x => x.Address2)
             .IsRequired(false)
             .HasMaxLength(1000);
            builder.Property(x => x.Address3)
            .IsRequired(false)
            .HasMaxLength(1000);
            builder.Property(x => x.Address4)
            .IsRequired(false)
            .HasMaxLength(1000);
            builder.Property(x => x.Town)
            .IsRequired(false)
            .HasMaxLength(50);
            builder.Property(x => x.PostCode)
         .IsRequired(false)
         .HasMaxLength(20);
            builder.Property(x => x.DateUploaded)
               .HasDefaultValueSql("getDate()");
        }
    }

}


