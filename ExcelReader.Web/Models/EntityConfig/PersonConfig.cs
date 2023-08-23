using ExcelReader.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Web.Models.EntityConfig
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Person> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName)
              .IsRequired()
              .HasMaxLength(250);

            builder.Property(x => x.LastName)
              .IsRequired()
              .HasMaxLength(250);
            builder.Property(x => x.MiddleName)
             .IsRequired()
             .HasMaxLength(250);
            builder.Property(x => x.DateUploaded)
               .HasDefaultValueSql("getDate()");
        }
    }
}
