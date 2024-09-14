using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DmitriySerebryakovKt_31_21.Models;
using DmitriySerebryakovKt_31_21.Database.Helpers;

namespace DmitriySerebryakovKt_31_21.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                .HasKey(d => d.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            builder.Property(d => d.DisciplineId)
                .ValueGeneratedOnAdd()
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор дисциплины");

            builder.Property(d => d.DisciplineName)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название дисциплины");

            builder.ToTable(TableName);
        }
    }
}
