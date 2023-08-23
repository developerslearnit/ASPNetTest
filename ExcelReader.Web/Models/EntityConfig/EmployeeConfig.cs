using ExcelReader.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Web.Models.EntityConfig
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.OrgNumber)
              .IsRequired()
              .HasMaxLength(10);

            builder.Property(x => x.FirstName)
              .IsRequired()
              .HasMaxLength(250);
            builder.Property(x => x.LastName)
             .IsRequired()
             .HasMaxLength(250);
            builder.Property(x => x.DateUploaded)
               .HasDefaultValueSql("getDate()");
        }
    }

}


