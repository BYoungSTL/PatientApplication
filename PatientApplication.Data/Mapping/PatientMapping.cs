using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientApplication.Data.Entities;
using PatientApplication.Data.Enums;

namespace PatientApplication.Data.Mapping
{
    public class PatientMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable(nameof(Patient));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("NameId").IsRequired();
            builder.Property(x => x.Gender).HasConversion(new EnumToStringConverter<Gender>()).HasColumnName("Gender").IsRequired();
            builder.Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
            builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired();

            builder.HasOne(x => x.Name).WithOne(x => x.Patient).HasForeignKey<Name>();
        }
    }
}
