using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DmitriySerebryakovKt_31_21.Models;
using DmitriySerebryakovKt_31_21.Database.Helpers;

namespace DmitriySerebryakovKt_31_21.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(TableName);

            builder
                .HasKey(p => p.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_teacher_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_teacher_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_teacher_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

            // Кафедра
            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID кафедры");

            builder.HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.Department)
                .AutoInclude();

            // Должность
            builder.Property(p => p.PositionId)
                .HasColumnName("position_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID должности");

            builder.HasOne(p => p.Position)
                .WithMany()
                .HasForeignKey(p => p.PositionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.Position)
                .AutoInclude();

            // Ученые степени
            builder.Property(p => p.AcademicDegreeId)
                .HasColumnName("academicdegree_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID ученой степени");

            builder.HasOne(p => p.AcademicDegree)
                .WithMany()
                .HasForeignKey(p => p.AcademicDegreeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.AcademicDegree)
                .AutoInclude();

            // Дисциплины
            builder.HasMany(p => p.Disciplines)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.Disciplines)
                .AutoInclude();

            // Учебная нагрузка
            builder.Property(p => p.TeachingLoadId)
                .HasColumnName("teachingload_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID нагрузки");

            builder.HasOne(p => p.TeachingLoad)
                .WithOne()
                .HasForeignKey<TeachingLoad>(p => p.TeachingLoadId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.TeachingLoad)
                .AutoInclude();

            builder.ToTable(TableName);
        }
    }
}
