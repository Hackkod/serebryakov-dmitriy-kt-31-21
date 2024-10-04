﻿// <auto-generated />
using System;
using DmitriySerebryakovKt_31_21.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DmitriySerebryakovKt_31_21.Migrations
{
    [DbContext(typeof(TeacherDbContext))]
    partial class TeacherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.AcademicDegree", b =>
                {
                    b.Property<int>("AcademicDegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("academic_degree_id")
                        .HasComment("Идентификатор академической степени");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AcademicDegreeId"));

                    b.Property<string>("AcademicDegreeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_academic_degree_name")
                        .HasComment("Название академической степени");

                    b.HasKey("AcademicDegreeId")
                        .HasName("pk_cd_academic_degree_academic_degree_id");

                    b.ToTable("cd_academic_degree", (string)null);
                });

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор кафедры");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_department_name")
                        .HasComment("Название кафедры");

                    b.HasKey("DepartmentId")
                        .HasName("pk_cd_department_department_id");

                    b.ToTable("cd_department", (string)null);
                });

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.Discipline", b =>
                {
                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("discipline_id")
                        .HasComment("Идентификатор дисциплины");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DisciplineId"));

                    b.Property<string>("DisciplineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_discipline_name")
                        .HasComment("Название дисциплины");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("integer")
                        .HasColumnName("teacher_id")
                        .HasComment("Идентификатор преподавателя");

                    b.HasKey("DisciplineId")
                        .HasName("pk_cd_discipline_discipline_id");

                    b.HasIndex(new[] { "TeacherId" }, "idx_cd_discipline_fk_teacher_id");

                    b.ToTable("cd_discipline", (string)null);
                });

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("position_id")
                        .HasComment("Идентификатор должности");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PositionId"));

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_position_name")
                        .HasComment("Название должности");

                    b.HasKey("PositionId")
                        .HasName("pk_cd_position_position_id");

                    b.ToTable("cd_position", (string)null);
                });

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("teacher_id")
                        .HasComment("Идентификатор преподавателя");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeacherId"));

                    b.Property<int?>("AcademicDegreeId")
                        .HasColumnType("int4")
                        .HasColumnName("academicdegree_id")
                        .HasComment("Идентификатор ученой степени");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int4")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор кафедры");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_lastname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_middlename")
                        .HasComment("Отчество преподавателя");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int4")
                        .HasColumnName("position_id")
                        .HasComment("Идентификатор должности");

                    b.Property<int?>("TeachingLoadId")
                        .HasColumnType("int4")
                        .HasColumnName("teachingload_id")
                        .HasComment("Идентификатор нагрузки");

                    b.HasKey("TeacherId")
                        .HasName("pk_cd_teacher_teacher_id");

                    b.HasIndex(new[] { "AcademicDegreeId" }, "idx_cd_teacher_fk_academicdegree_id");

                    b.HasIndex(new[] { "DepartmentId" }, "idx_cd_teacher_fk_department_id");

                    b.HasIndex(new[] { "PositionId" }, "idx_cd_teacher_fk_position_id");

                    b.HasIndex(new[] { "TeachingLoadId" }, "idx_cd_teacher_fk_teachingload_id");

                    b.ToTable("cd_teacher", (string)null);
                });

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.TeachingLoad", b =>
                {
                    b.Property<int>("TeachingLoadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("teaching_load_id")
                        .HasComment("Идентификатор нагрузки на преподавателя");

                    b.Property<int>("Hours")
                        .HasColumnType("int4")
                        .HasColumnName("c_hours")
                        .HasComment("Количество часов");

                    b.HasKey("TeachingLoadId")
                        .HasName("pk_cd_teaching_load_teaching_load_id");

                    b.ToTable("cd_teaching_load", (string)null);
                });

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.Discipline", b =>
                {
                    b.HasOne("DmitriySerebryakovKt_31_21.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_teacher_id");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.Teacher", b =>
                {
                    b.HasOne("DmitriySerebryakovKt_31_21.Models.AcademicDegree", "AcademicDegree")
                        .WithMany()
                        .HasForeignKey("AcademicDegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_academicdegree_id");

                    b.HasOne("DmitriySerebryakovKt_31_21.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_department_id");

                    b.HasOne("DmitriySerebryakovKt_31_21.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_position_id");

                    b.Navigation("AcademicDegree");

                    b.Navigation("Department");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.TeachingLoad", b =>
                {
                    b.HasOne("DmitriySerebryakovKt_31_21.Models.Teacher", null)
                        .WithOne("TeachingLoad")
                        .HasForeignKey("DmitriySerebryakovKt_31_21.Models.TeachingLoad", "TeachingLoadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_teachingload_id");
                });

            modelBuilder.Entity("DmitriySerebryakovKt_31_21.Models.Teacher", b =>
                {
                    b.Navigation("TeachingLoad")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
