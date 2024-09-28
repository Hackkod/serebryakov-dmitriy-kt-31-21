using DmitriySerebryakovKt_31_21.Database;
using DmitriySerebryakovKt_31_21.Filters.TeacherFilters;
using DmitriySerebryakovKt_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace DmitriySerebryakovKt_31_21.Interfaces.TeachersInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;
        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _dbContext.Set<Teacher>().Where(w => w.Department.DepartmentName == filter.DepartmentName).ToArrayAsync(cancellationToken);

            return teachers;
        }
    }
}
