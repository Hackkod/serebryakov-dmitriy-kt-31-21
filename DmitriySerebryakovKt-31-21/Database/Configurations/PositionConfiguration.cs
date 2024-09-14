using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DmitriySerebryakovKt_31_21.Models;
using DmitriySerebryakovKt_31_21.Database.Helpers;

namespace DmitriySerebryakovKt_31_21.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "cd_position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder
                .HasKey(p => p.PositionId)
                .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.PositionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("position_id")
                .HasComment("Идентификатор должности");

            builder.Property(p => p.PositionName)
                .IsRequired()
                .HasColumnName("c_position_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название должности");

            builder.ToTable(TableName);
        }
    }
}
