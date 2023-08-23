using ExcelReader.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Web.Models.EntityConfig
{
    public class SchoolConfig : IEntityTypeConfiguration<School>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<School> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.SchoolClass)
              .IsRequired()
              .HasMaxLength(250);

            builder.Property(x => x.Name)
              .IsRequired()
              .HasMaxLength(250);
            builder.Property(x => x.Description)
             .IsRequired()
             .HasMaxLength(250);
            builder.Property(x => x.DateUploaded)
               .HasDefaultValueSql("getDate()");
        }
    }
}
