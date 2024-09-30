using DmitriySerebryakovKt_31_21.Database;
using DmitriySerebryakovKt_31_21.Filters.TeacherFilters;
using DmitriySerebryakovKt_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace DmitriySerebryakovKt_31_21.Interfaces.TeachersInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher[]> GetTeachersAsync(CancellationToken cancellationToken);
        public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
        public Task<Teacher[]> GetTeachersWithTeachingLoadAsync(TeacherDepartmentDisciplineFilter filter, CancellationToken cancellationToken);

        public Task AddDisciplineAsync(int teacherId, string disciplineName, CancellationToken cancellationToken);
        public Task UpdateDisciplineAsync(int disciplineId, string newDisciplineName, CancellationToken cancellationToken);
        public Task DeleteDisciplineAsync(int disciplineId, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;
        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher[]> GetTeachersAsync(CancellationToken cancellationToken = default)
        {
            var teachers = await _dbContext.Set<Teacher>().ToArrayAsync(cancellationToken);

            return teachers;
        }

        public async Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _dbContext.Set<Teacher>()
                .Where(w => 
                    (string.IsNullOrEmpty(filter.DepartmentName) || w.Department.DepartmentName == filter.DepartmentName))
                .ToArrayAsync(cancellationToken);

            return teachers;
        }

        public async Task<Teacher[]> GetTeachersWithTeachingLoadAsync(TeacherDepartmentDisciplineFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _dbContext.Set<Teacher>()
                .Include(t => t.Disciplines)
                .Include(t => t.TeachingLoad)
                .Where(t =>
                    (string.IsNullOrEmpty(filter.DepartmentName) || t.Department.DepartmentName == filter.DepartmentName) &&
                    (string.IsNullOrEmpty(filter.DisciplineName) || t.Disciplines.Any(d => d.DisciplineName == filter.DisciplineName)))
                .ToArrayAsync(cancellationToken);

            return teachers;
        }

        // Дисциплины

        public async Task AddDisciplineAsync(int teacherId, string disciplineName, CancellationToken cancellationToken = default)
        {
            var discipline = await _dbContext.Set<Discipline>().FirstOrDefaultAsync(t => t.TeacherId == teacherId);

            if (discipline != null)
            {
                var newDiscipline = new Discipline
                {
                    DisciplineName = disciplineName,
                    TeacherId = teacherId
                };

                _dbContext.Disciplines.Add(newDiscipline);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateDisciplineAsync(int disciplineId, string newDisciplineName, CancellationToken cancellationToken = default)
        {
            var discipline = await _dbContext.Set<Discipline>().FindAsync(disciplineId);

            if (discipline != null)
            {
                discipline.DisciplineName = newDisciplineName;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteDisciplineAsync(int disciplineId, CancellationToken cancellationToken = default)
        {
            var discipline = await _dbContext.Set<Discipline>().FindAsync(disciplineId);

            if (discipline != null)
            {
                _dbContext.Disciplines.Remove(discipline);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
