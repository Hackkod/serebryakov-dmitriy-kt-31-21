using DmitriySerebryakovKt_31_21.Database;
using DmitriySerebryakovKt_31_21.Interfaces.TeachersInterfaces;
using DmitriySerebryakovKt_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace DmitriySerebryakovKt_31_21.Tests
{
    public class TeacherIntegrationTests
    {
        public readonly DbContextOptions<TeacherDbContext> _dbContextOptions;

        public TeacherIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
            .UseInMemoryDatabase(databaseName: "teacher_db")
            .Options;
        }

        [Fact]
        public async Task GetTeachersByDepartmentAsync_KT3120_TwoObjects()
        {
            // Arrange
            var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);
            var departments = new List<Department>
            {
                new Department
                {
                    DepartmentName = "123"
                },
                new Department
                {
                    DepartmentName = "ИВТ"
                }
            };
            await ctx.Set<Department>().AddRangeAsync(departments);

            await ctx.SaveChangesAsync();

            var positions = new List<Position>
            {
                new Position
                {
                    PositionName = Position.PositionNameType.Lecturer
                },
                new Position
                {
                    PositionName = Position.PositionNameType.HeadLecturer
                }
            };
            await ctx.Set<Position>().AddRangeAsync(positions);

            await ctx.SaveChangesAsync();

            var academicdegrees = new List<AcademicDegree>
            {
                new AcademicDegree
                {
                    AcademicDegreeName = AcademicDegree.AcademicDegreeNameTypes.ScienceCandidate
                },
                new AcademicDegree
                {
                    AcademicDegreeName = AcademicDegree.AcademicDegreeNameTypes.ScienceDoctor
                }
            };
            await ctx.Set<AcademicDegree>().AddRangeAsync(academicdegrees);

            await ctx.SaveChangesAsync();

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    DepartmentId = 1,
                    PositionId = 1,
                    AcademicDegreeId = 1,
                },
                new Teacher
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    DepartmentId = 2,
                    PositionId = 2,
                    AcademicDegreeId = 2,
                }
            };
            await ctx.Set<Teacher>().AddRangeAsync(teachers);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.TeacherFilters.TeacherDepartmentFilter
            {
                DepartmentName = "123"
            };
            var teachersResult = await teacherService.GetTeachersByDepartmentAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, teachersResult.Length);
        }
    }
}
