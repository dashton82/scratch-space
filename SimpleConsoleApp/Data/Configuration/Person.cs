using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class Person  : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("datetime").IsRequired();

        }
    }
}