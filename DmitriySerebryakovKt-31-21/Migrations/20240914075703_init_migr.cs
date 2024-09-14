using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DmitriySerebryakovKt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class init_migr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_academic_degree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор академической степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_academic_degree_name = table.Column<int>(type: "integer", nullable: false, comment: "Название академической степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор отдела")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название отдела")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_position_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_teacher_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    department_id = table.Column<int>(type: "int4", nullable: false, comment: "ID кафедры"),
                    position_id = table.Column<int>(type: "int4", nullable: false, comment: "ID должности"),
                    academicdegree_id = table.Column<int>(type: "int4", nullable: false, comment: "ID ученой степени"),
                    teachingload_id = table.Column<int>(type: "int4", nullable: false, comment: "ID нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "FK_cd_teacher_cd_academic_degree_academicdegree_id",
                        column: x => x.academicdegree_id,
                        principalTable: "cd_academic_degree",
                        principalColumn: "academic_degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cd_teacher_cd_department_department_id",
                        column: x => x.department_id,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cd_teacher_cd_position_position_id",
                        column: x => x.position_id,
                        principalTable: "cd_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    TeacherId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                    table.ForeignKey(
                        name: "FK_cd_discipline_cd_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_teaching_load",
                columns: table => new
                {
                    teaching_load_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор нагрузки на преподавателя"),
                    c_hours = table.Column<int>(type: "int4", nullable: false, comment: "Количество часов")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teaching_load_teaching_load_id", x => x.teaching_load_id);
                    table.ForeignKey(
                        name: "FK_cd_teaching_load_cd_teacher_teaching_load_id",
                        column: x => x.teaching_load_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_discipline_TeacherId",
                table: "cd_discipline",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_academicdegree_id",
                table: "cd_teacher",
                column: "academicdegree_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_department_id",
                table: "cd_teacher",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_position_id",
                table: "cd_teacher",
                column: "position_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_teaching_load");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_academic_degree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_position");
        }
    }
}
