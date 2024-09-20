using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DmitriySerebryakovKt_31_21.Models;

namespace DmitriySerebryakovKt_31_21.Database.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "cd_academic_degree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder
                .HasKey(ad => ad.AcademicDegreeId)
                .HasName($"pk_{TableName}_academic_degree_id");

            builder.Property(ad => ad.AcademicDegreeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("academic_degree_id")
                .HasComment("Идентификатор академической степени");

            builder.Property(ad => ad.AcademicDegreeName)
                .IsRequired()
                .HasColumnName("c_academic_degree_name")
                .HasComment("Название академической степени");

            builder.ToTable(TableName);
        }
    }
}
