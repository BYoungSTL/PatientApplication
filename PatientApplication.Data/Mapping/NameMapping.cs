using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientApplication.Data.Entities;

namespace PatientApplication.Data.Mapping
{
    public class NameMapping : IEntityTypeConfiguration<Name>
    {
        public void Configure(EntityTypeBuilder<Name> builder)
        {
            builder.ToTable(nameof(Name));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Given)
                .HasConversion(x => ConfigureGivenToDb(x), v => ConfigureGivenFromDb(v))
                .HasColumnName("Given").HasColumnType("nvarchar").HasMaxLength(128);
            builder.Property(x => x.Use).HasColumnName("Use");
            builder.Property(x => x.Family).HasColumnName("Family").IsRequired();
        }

        private static string ConfigureGivenToDb(IReadOnlyList<string> given)
            => given[0] + ", " + given[1];


        private static string[] ConfigureGivenFromDb(string given) 
            => given.Split(", ");
    }
}
